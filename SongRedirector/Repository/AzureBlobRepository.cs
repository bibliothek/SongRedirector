using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace SongRedirector.Repository
{
    public class AzureBlobRepository : FileRepositoryBase
    {
        private BlobStorageSettings settings;
        private CloudBlobClient client;
        private CloudBlobContainer container;

        public AzureBlobRepository(IOptions<BlobStorageSettings> options)
        {
            settings = options.Value;

            if (!CloudStorageAccount.TryParse(settings.ConnectionString, out var account))
            {
                throw new Exception("No valid connection string");
            }
            client = account.CreateCloudBlobClient();
            container = client.GetContainerReference(settings.ContainerName);
        }



        protected override Stream GetFileStream(string configName)
        {
            var blob = container.GetBlockBlobReference(configName + ".songs");
            var memStream = new MemoryStream();
            blob.DownloadToStreamAsync(memStream).Wait();
            memStream.Position = 0;
            return memStream;

        }
    }
}
