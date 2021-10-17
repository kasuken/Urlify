using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urlify.Shared;

namespace Urlify.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlifyController : ControllerBase
    {
        private readonly ILogger<UrlifyController> _logger;
        private readonly IUrlifyService _urlifyDbService;

        public UrlifyController(ILogger<UrlifyController> logger, IUrlifyService liteDbUrlifyService)
        {
            _logger = logger;
            _urlifyDbService = liteDbUrlifyService;
        }

        [HttpGet]
        public IEnumerable<UrlifyLink> Get()
        {
            return _urlifyDbService.FindAll();
        }

        [HttpGet("GetById/{shortUrl}")]
        public UrlifyLink GetById(string shortUrl)
        {
            var hashids = new Hashids("this is my salt urlify", 10);
            var id = hashids.Decode(shortUrl);

            var link = _urlifyDbService.FindOne(id.FirstOrDefault());

            return link;
        }

        [HttpPost]
        public UrlifyLink Post(UrlifyLink urlifyLink)
        {
            var id = _urlifyDbService.Insert(urlifyLink);

            var urlShort = _urlifyDbService.FindOne(id);

            var hashids = new Hashids("this is my salt urlify", 10);
            var hash = hashids.Encode(id);

            urlShort.ShortUrl = hash;

            _urlifyDbService.Update(urlShort);

            return urlShort;
        }
    }
}
