using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongRedirector.Models;
using SongRedirector.Repository;

namespace SongRedirector.Controllers
{
    [Route("api/config")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ILinkRepository linkRepository;

        public ConfigController(ILinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        [HttpGet]
        public IEnumerable<string> GetConfigs()
        {
            return linkRepository.GetConfigNames();
        }

        [HttpGet("{name}")]
        public Config GetConfig(string name)
        {
            var c = linkRepository.GetConfig(name);
            return new Config
            {
                Name = c.Name,
                Links = c.Links
            };
        }
    }
}