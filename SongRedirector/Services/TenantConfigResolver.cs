using System.Collections.Generic;

namespace SongRedirector.Services
{
    public class TenantConfigResolver : ITenantConfigResolver
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

                var fileLinkProvider = new EmbeddedFileLinkProvider(config);
                tenantProviders.Add(config, fileLinkProvider);
                return fileLinkProvider;
            }
        }
    }
}