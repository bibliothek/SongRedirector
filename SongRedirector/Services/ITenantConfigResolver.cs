namespace SongRedirector.Services
{
    public interface ITenantConfigResolver
    {
        ILinkProvider Resolve(string tenant);
    }
}