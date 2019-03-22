using SongRedirector.Services;
using Xunit;

namespace SongRedirector.Tests
{
    public class TenantLinkProvider_ProvidesTenantLinks
    {

        [Fact]
        public void TenantLinkProvider_ProvidesTenantLinks_FindTenant()
        {
            TenantLinkProvider tenantLinkProvider = new TenantLinkProvider();
            var provider = tenantLinkProvider.Resolve("nexoneers");
            var result = provider.GetLink();

            Assert.NotNull(result);
        }

        [Fact]
        public void TenantLinkProvider_ProvidesTenantLinks_DefaultTenant()
        {
            TenantLinkProvider tenantLinkProvider = new TenantLinkProvider();
            var provider = tenantLinkProvider.Resolve("");
            var result = provider.GetLink();

            Assert.NotNull(result);
        }
    }
}