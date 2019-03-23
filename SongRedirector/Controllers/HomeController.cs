using SongRedirector.Services;
using Microsoft.AspNetCore.Mvc;

namespace SongRedirector.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkProvider linkProvider;

        public HomeController(ILinkProvider linkProvider)
        {
            this.linkProvider = linkProvider;
        }
        public IActionResult Index([FromQuery] string tenant = "")
        {
            var uri = linkProvider.GetLink(tenant);
            return Redirect(uri);
        }

    }
}
