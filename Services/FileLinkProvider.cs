using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;

public class FileLinkProvider : RandomLinkProvider
{
    public string FileName { get; }
    public FileLinkProvider(string fileName)
    {
        FileName = fileName;
    }

    Regex regex = new Regex("(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)");

    protected override IEnumerable<Link> GetLinkList()
    {
        var assembly = typeof(TenantLinkProvider).Assembly;
        using (Stream resource = assembly.GetManifestResourceStream(FileName))
        using (var reader = new StreamReader(resource))
        using (var csv = new CsvReader(reader))
        {
            var records = csv.GetRecords<Link>();
        }
    }
}