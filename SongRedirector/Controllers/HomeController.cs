using SongRedirector.Services;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Repository;
using System.Text;
using System.Linq;
using System;

namespace SongRedirector.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkProvider linkProvider;
        private readonly ILinkRepository linkRepository;

        public HomeController(ILinkProvider linkProvider, ILinkRepository linkRepository)
        {
            this.linkProvider = linkProvider;
            this.linkRepository = linkRepository;
        }
        public IActionResult Index([FromQuery] string tenant = "")
        {
            var uri = linkProvider.GetLink(tenant);
            return Redirect(uri);
        }

        public IActionResult List([FromQuery] string tenant = "")
        {
            var config = linkRepository.GetConfig(tenant);
            var sb = new StringBuilder();
            foreach(var link in config.Links)
            {
                sb.Append($"{link.DisplayName}: {link.Uri} (Probability: {link.Probability}){Environment.NewLine}");
            }
            return Content(sb.ToString());
        }

    }
}
