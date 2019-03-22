using System.Collections.Generic;
using System.IO;
namespace SongRedirector.Services
{
    public class TenantLinkProvider : ITenantLinkProvider
    {

        private Dictionary<string, ILinkProvider> tenantProviders = new Dictionary<string, ILinkProvider>();

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
            lock (tenantProviders)
            {

                if (tenantProviders.TryGetValue(tenant, out ILinkProvider tenantProvider))
                {
                    return tenantProvider;
                }

                var fileLinkProvider = new FileLinkProvider(tenant + ".songs");
                tenantProviders.Add(tenant, fileLinkProvider);
                return fileLinkProvider;
            }
        }
    }
}