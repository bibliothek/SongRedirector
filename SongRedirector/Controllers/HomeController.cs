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
        public IActionResult Index([FromRoute]string config = "")
        {
            var uri = linkProvider.GetLink(config);
            return Redirect(uri);
        }

    }
}
