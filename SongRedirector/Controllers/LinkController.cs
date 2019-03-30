using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Repository;

namespace SongRedirector.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkRepository linkRepository;

        public LinkController(ILinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public IActionResult Create([FromRoute]string config = "")
        {
            return View();
        }

        public IActionResult Edit([FromRoute]string config = "", [FromRoute]int id = 0)
        {
            var link = linkRepository.GetLink(config, id);
            return View();
        }

        public IActionResult Delete([FromRoute]string config = "", [FromRoute]int id = 0)
        {
            linkRepository.Delete(config, id);
            return RedirectToAction("Index", "Config",new { config});
        }
    }
}