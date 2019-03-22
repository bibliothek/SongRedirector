using System.Collections.Generic;
using System.IO;
namespace SongRedirector.Services
{
    public class TenantLinkProvider : ITenantLinkProvider
    {

        private Dictionary<string, ILinkProvider> tenantProviders = new Dictionary<string, ILinkProvider>();

        public ILinkProvider Resolve(string tenant)
        {
            var config = string.IsNullOrEmpty(tenant) ? "default" : tenant;
            lock (tenantProviders)
            {

                if (tenantProviders.TryGetValue(config, out ILinkProvider tenantProvider))
                {
                    return tenantProvider;
                }

                var fileLinkProvider = new FileLinkProvider(config + ".songs");
                tenantProviders.Add(config, fileLinkProvider);
                return fileLinkProvider;
            }
        }
    }
}