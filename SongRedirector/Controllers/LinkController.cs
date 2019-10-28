using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Models;
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

        [HttpGet]
        public IActionResult Create([FromRoute]string config)
        {
            return View(new LinkModel() { ConfigName = config});
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]string config, [FromRoute]int id)
        {
            var link = linkRepository.GetLink(config, id);
            return View(new LinkModel(config, link, linkRepository.GetConfigNames()));
        }

        public IActionResult Upvote([FromRoute]string config, [FromRoute]int id)
        {
            linkRepository.ChangeProbability(config, id, 1);
            return Ok();
        }

        public IActionResult Downvote([FromRoute]string config, [FromRoute]int id)
        {
            linkRepository.ChangeProbability(config, id, -1);
            return Ok();
        }

        [HttpPost]
        public IActionResult Save(LinkModel linkModel)
        {
            linkRepository.Save(linkModel.ConfigName, linkModel.Link);
            return RedirectToAction("Index", "Config", new { config = linkModel.ConfigName });
        }

        public IActionResult Delete([FromRoute]string config, [FromRoute]int id)
        {
            linkRepository.Delete(config, id);
            return RedirectToAction("Index", "Config",new { config});
        }
    }
}