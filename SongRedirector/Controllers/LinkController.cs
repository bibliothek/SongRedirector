using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Models;
using SongRedirector.Repository;
using SongRedirector.Services;

namespace SongRedirector.Controllers
{
    [Route("api/config/{config}/link")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkProvider linkProvider;
        private readonly ILinkRepository linkRepository;

        public LinkController(ILinkProvider linkProvider, ILinkRepository linkRepository)
        {
            this.linkProvider = linkProvider;
            this.linkRepository = linkRepository;
        }

        [HttpGet]
        public Link GetRandomLink(string config)
        {
            return linkProvider.GetLink(config);
        }

        [HttpGet("{id}")]
        public Link GetLink(string config, int id)
        {
            return linkRepository.GetLink(config, id);
        }

        [HttpPost("{id}/upvote")]
        public OkResult Upvote(string config, int id)
        {
            linkRepository.ChangeProbability(config, id, 1);
            return Ok();
        }

        [HttpPost("{id}/downvote")]
        public OkResult Downvote(string config, int id)
        {
            linkRepository.ChangeProbability(config, id, -1);
            return Ok();
        }

    }
}