using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Data.Models.MetaData;

namespace PersonalManager.Controllers
{
    [Route("MetaData")]
    [Authorize]
    public class MetaDataController : Controller
    {

       [HttpGet("byURL/{url}")]
        public JsonResult byURL(string url)
        {
            string decodedUrl = System.Net.WebUtility.UrlDecode(url);
            MetaInformation metaInfo = MetaScraper.GetMetaDataFromUrl(decodedUrl);
            return Json(metaInfo);
        }
    }
}
