using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortner.App_Code;

namespace UrlShortner.Controllers
{
    public class UrlController : Controller
    {
        // GET: Url
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrlRedirect(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                UrlDB urlShort = new UrlDB();
                urlShort.GetByShortUrl(id);

                if (urlShort.UrlShort != null)
                    return this.Redirect(urlShort.UrlLong);
                else
                    return this.Redirect("/");
            }
            else
                return this.Redirect("/"); ;
        }
    }
}