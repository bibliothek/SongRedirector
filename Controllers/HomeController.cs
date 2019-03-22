using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            string uri = linkProvider.GetLink(tenant);
            return Redirect(uri);
        }

    }
}
