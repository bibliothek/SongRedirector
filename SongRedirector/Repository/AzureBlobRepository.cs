using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SongRedirector.Repository
{
    public class AzureBlobRepository : FileRepositoryBase
    {
        private readonly CloudBlobClient client;
        private IList<string> configNames;
        private readonly CloudBlobContainer container;
        private readonly BlobStorageSettings settings;

        public AzureBlobRepository(IOptions<BlobStorageSettings> options)
        {
            settings = options.Value;

            if (!CloudStorageAccount.TryParse(settings.ConnectionString, out var account))
                throw new Exception("No valid connection string");
            client = account.CreateCloudBlobClient();
            container = client.GetContainerReference(settings.ContainerName);
        }

        protected override void DeleteInternal(string configName, int id)
        {
            var conf = GetConfig(configName);
            var newLinks = conf.Links.Where(x => x.Id != id).ToArray();
            var newConf = new LinkConfig(newLinks, configName);
            Save(configName, newConf);
        }

        private void Save(string configName, ILinkConfig linkConfig)
        {
            var blob = container.GetBlockBlobReference(configName + ".songs");
            var tempFile = Path.GetTempFileName();
            using (var stream = File.OpenWrite(tempFile))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.WriteRecords(linkConfig.Links);
            }

            blob.UploadFromFileAsync(tempFile).Wait();
            File.Delete(tempFile);
        }

        protected override Stream GetFileStream(string configName)
        {
            var blob = container.GetBlockBlobReference(configName + ".songs");
            var memStream = new MemoryStream();
            try
            {
                blob.DownloadToStreamAsync(memStream).Wait();
            }
            catch (AggregateException)
            {
                throw new NoValidConfigException(configName);
            }

            memStream.Position = 0;
            return memStream;
        }

        internal override void SaveInternal(string configName, ILinkConfig linkConfig)
        {
            Save(configName, linkConfig);
        }

        public override IList<string> GetConfigNames()
        {
            if (configNames != null) return configNames;
            container.CreateIfNotExistsAsync().Wait();
            var segment = container.ListBlobsSegmentedAsync(null).Result;
            var list = new List<IListBlobItem>();
            list.AddRange(segment.Results);
            while (segment.ContinuationToken != null)
            {
                segment = container.ListBlobsSegmentedAsync(segment.ContinuationToken).Result;
                list.AddRange(segment.Results);
            }

            if (!list.Any())
            {
                InitializeWithEmbeddedConfigs(list); 
            }

            const string configNameRegex = @"^.*\/(.+)\.songs$";

            configNames = list.Select(x => Regex.Match(x.Uri.AbsolutePath, configNameRegex).Groups[1].Value).ToList();
            return configNames;
        }

        private void InitializeWithEmbeddedConfigs(List<IListBlobItem> list)
        {
            var embeddedFileRepo = new EmbeddedFileRepository();
            configNames = embeddedFileRepo.GetConfigNames();
            foreach (var configName in configNames)
            {
                var config = embeddedFileRepo.GetConfig(configName);
                Save(configName, config);
            }
        }
    }
}