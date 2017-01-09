using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusClient.Controllers
{
    [Route("test")]
    [Route("schoolbus/test")]
    public class TestController : Controller
    {
        /// <summary>
        /// Echos request headers
        /// </summary>
        /// <returns>
        /// The request headers formatted as html
        /// </returns>
        [HttpGet]
        [Route("headers")]
        [Produces("text/html")]
        public virtual IActionResult EchoHeaders()
        {
            string content = HeadersToHtml(Request.Headers);
            string html = CloseHtml(content);
            return Ok(html);
        }

        private string HeadersToHtml(IHeaderDictionary headers)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<b>Request Headers:</b>");
            html.AppendLine("<ul style=\"list-style-type:none\">");
            foreach (var item in headers)
            {
                html.AppendFormat("<li><b>{0}</b> = {1}</li>\r\n", item.Key, ExpandValue(item.Value));
            }
            html.AppendLine("</ul>");
            return html.ToString();
        }

        private string CloseHtml(string content)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html>");
            html.AppendLine("<body>");
            html.Append(content);
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString();
        }

        /// <summary>
        /// Utility function used to expand headers.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private string ExpandValue(IEnumerable<string> values)
        {
            StringBuilder value = new StringBuilder();

            foreach (string item in values)
            {
                if (value.Length > 0)
                {
                    value.Append(", ");
                }
                value.Append(item);
            }
            return value.ToString();
        }
    }
}
