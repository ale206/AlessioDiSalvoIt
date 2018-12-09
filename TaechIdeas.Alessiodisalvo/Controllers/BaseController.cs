using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace TaechIdeas.Alessiodisalvo.Controllers
{
    public class BaseController : Controller
    {
        private string IsoLanguage { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var browserLanguages = Request.UserLanguages;

            if (Session["IsoLanguage"] == null || (string) Session["IsoLanguage"] == "")
            {
                IsoLanguage = browserLanguages[0];

                if (IsoLanguage.Contains("-"))
                {
                    IsoLanguage = IsoLanguage.Split('-')[0];
                }
            }
            else
            {
                if (filterContext.RouteData.Values.ContainsKey("lang"))
                {
                    if (filterContext.RouteData.Values["lang"].ToString().ToLower() == "undefined")
                    {
                        filterContext.RouteData.Values["lang"] = Session["IsoLanguage"].ToString();
                    }
                }

                IsoLanguage = filterContext.RouteData.Values["lang"].ToString().ToLower();
            }

            Session["IsoLanguage"] = IsoLanguage;

            ViewBag.isoLanguage = IsoLanguage;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(IsoLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(IsoLanguage);
        }
    }
}