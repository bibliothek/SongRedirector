using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
namespace SongRedirector.Services
{
public class FileLinkProvider : RandomLinkProvider
{
    public string FileName { get; private set; }
    public FileLinkProvider(string fileName)
    {
        Debug.WriteLine(fileName);
        FileName = fileName;
    }
    protected override IEnumerable<Link> GetLinkList()
    {
        var assembly = typeof(TenantConfigResolver).Assembly;
        string filePath =  "SongRedirector.songs." + FileName;
        using (Stream resource = assembly.GetManifestResourceStream(filePath))
        {
            if (resource == null)
            {
                throw new FileNotFoundException(filePath);
            }
            using (var reader = new StreamReader(resource))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ";";
                return csv.GetRecords<Link>().ToArray();
            }
        }

    }
}
}