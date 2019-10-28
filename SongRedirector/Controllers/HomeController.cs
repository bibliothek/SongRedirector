﻿using SongRedirector.Services;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Repository;
using System.Text;
using System.Linq;
using System;
using SongRedirector.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

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
        public IActionResult Index([FromRoute]string config)
        {
            return Forward(config);
        }

        public IActionResult Forward([FromRoute]string config)
        {
            var link = linkProvider.GetLink(config);
            return Redirect(link.Uri);
        }

        public IActionResult Embed([FromRoute]string config)
        {
            var link = linkProvider.GetLink(config);
            if (string.IsNullOrEmpty(link.GetYouTubeEmbedCode()))
            {
                return Redirect(link.Uri);
            }
            var model = new HomeModel(linkRepository.GetConfigNames()) { Link = link, ConfigName = config};
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            var noValidConfigException = exception as NoValidConfigException;
            if (noValidConfigException != null)
            {
                errorViewModel.Message = noValidConfigException.ToString();
            }
            return View(errorViewModel);
        }
    }
}
