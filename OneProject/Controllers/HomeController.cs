using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OneProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string RSSURL;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            RSSURL = @"http://www.walla.co.il/rss";
            RssData.LoadCategories();
        }

        public IActionResult Index()
        {
            return View();
        } 

        [HttpGet]
        public JsonResult GetCategories()
        {
            return Json(RssData.Categories);
        }

        [HttpGet]

        public JsonResult GetItems(string id)
        {
                if(id == null)
            {
                id = "0";
            }
                int categoryLocation = int.Parse(id);
                string categoryLink = RssData.Categories[categoryLocation].Link;
                WebClient wclient = new WebClient();
                string RSSData = wclient.DownloadString(categoryLink);

                XDocument xml = XDocument.Parse(RSSData);
                var RSSFeedData = (from x in xml.Descendants("item")
                                   select new RssReader
                                   {
                                       Title = ((string)x.Element("title")),
                                       Link = ((string)x.Element("link")),
                                       Description = ((string)x.Element("description")),
                                       Date = ((string)x.Element("pubDate"))
                                   });

                return Json(RSSFeedData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
