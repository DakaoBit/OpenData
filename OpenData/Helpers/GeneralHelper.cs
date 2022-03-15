using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace OpenData.Helpers
{
    public static class GeneralHelper
    {
        public static string ChangeTaiwanCalendar(this DateTime x, string format)
        {
            var tc = new TaiwanCalendar();

            var regex = new Regex(@"[yY]");
            format = regex.Replace(format, tc.GetYear(x).ToString("000"));
            return x.ToString(format);
        }

        public static MvcHtmlString HightLightText(this HtmlHelper helper, string text)
        {
          
            List<TagBuilder> builderList = new List<TagBuilder>();
            string strOutput = "";

            string[] strArray = text.Split(';');
            string desc = strArray.First();
            strArray = strArray.Skip(1).ToArray();

            foreach (var item in strArray)
            {
                var builder = new TagBuilder("a");
                builder = new TagBuilder("a");
                builder.InnerHtml = item;
                builderList.Add(builder);
            }

            foreach (var item in builderList)
            {
                strOutput += item + " ; ";

            }
            return MvcHtmlString.Create(desc + "<br/>" + strOutput);
        }

        public static string UrlLink(this HtmlHelper helper, HttpRequest httpRequest, string Action, string Controller, object routeValues)
        {
            var requestContext = httpRequest.RequestContext;
            return new UrlHelper(requestContext).Action(Action, Controller, routeValues);
        }
    }
}