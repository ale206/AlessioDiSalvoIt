using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace TaechIdeas.Alessiodisalvo.Controllers
{
    public static class Localization
    {
        public static MvcHtmlString Localize(string id)
        {
            return new MvcHtmlString(GetResource(id));
        }

        #region GetResource

        private static string GetResource(string id)
        {
            var culture = HttpContext.Current.Session["IsoLanguage"].ToString();

            if (String.IsNullOrEmpty(culture) || culture == "undefined")
            {
                culture = ConfigurationManager.AppSettings["DefaultLanguage"];
                HttpContext.Current.Session["IsoLanguage"] = culture;
            }

            var uniqueApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
            var xmlFolderName = ConfigurationManager.AppSettings["LocalizationFolder"];

            // If used more than once on a server, enter a unique id for each project.
            var applicationName = string.Format("{0}_{1}_", culture, uniqueApplicationName);

            var path = HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}.xml", xmlFolderName, culture));

            GetXmlResource(path, applicationName);

            return HttpContext.Current.Application[applicationName + id] == null
                ? null
                : HttpContext.Current.Application[applicationName + id].ToString();
        }

        #endregion

        #region GetXmlResource

        private static void GetXmlResource(string path, string applicationName)
        {
            var doc = new XmlTextReader(path);
            var xml = new XmlDocument();
            xml.Load(doc);

            if (xml.DocumentElement != null)
            {
                var nodes = xml.DocumentElement.SelectSingleNode("//lang");

                if (nodes == null)
                    return;

                if (nodes.ChildNodes.Count == 0)
                    return;

                for (var nod = 0; nod <= nodes.ChildNodes.Count - 1; nod++)
                {
                    var xmlNode = nodes.ChildNodes.Item(nod);
                    if (xmlNode == null) continue;
                    if (xmlNode.Attributes == null) continue;
                    var itemId = xmlNode.Attributes.Item(0).InnerText;
                    var itemValue = xmlNode.InnerText;

                    HttpContext.Current.Application[applicationName + itemId] = itemValue;
                }
            }
            xml.Clone();
            doc.Close();
        }

        #endregion
    }
}