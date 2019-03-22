using SongRedirector.Services;
using Xunit;

namespace SongRedirector.Tests
{
    public class TenantConfigResolver_ProvidesTenantConfigs
    {

        [Fact]
        public void TenantConfigResolver_ProvidesTenantConfig_FindTenant()
        {
            TenantConfigResolver tenantConfigResolver = new TenantConfigResolver();
            var provider = tenantConfigResolver.Resolve("nexoneers");
            var result = provider.GetLink();

            Assert.NotNull(result);
        }

        [Fact]
        public void TenantConfigResolver_ProvidesTenantConfig_DefaultTenant()
        {
            TenantConfigResolver tenantConfigResolver = new TenantConfigResolver();
            var provider = tenantConfigResolver.Resolve("");
            var result = provider.GetLink();

            Assert.NotNull(result);
        }
    }
}