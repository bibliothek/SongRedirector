namespace SongRedirector.Services
{
    public interface ITenantLinkProvider
    {
        ILinkProvider Resolve(string tenant);
    }
}