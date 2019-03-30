using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Models;
using SongRedirector.Repository;

namespace SongRedirector.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ILinkRepository linkRepository;

        public ConfigController(ILinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public IActionResult Index([FromRoute]string config = "")
        {
            var conf = linkRepository.GetConfig(config);
            return View(new ConfigModel(conf));
        }
        

    }
}