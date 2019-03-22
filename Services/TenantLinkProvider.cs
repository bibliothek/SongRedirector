using System.IO;

public interface ITenantLinkProvider
{
    ILinkProvider Resolve(string tenant);
}
public class TenantLinkProvider : ITenantLinkProvider
{
    private ILinkProvider defaultProvider;

    public TenantLinkProvider(ILinkProvider defaultProvider)
    {
        this.defaultProvider = defaultProvider;
    }
    public ILinkProvider Resolve(string tenant)
    {
        if (string.IsNullOrWhiteSpace(tenant))
        {
            return defaultProvider;
        }


    }
}