using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusCommon
{
    public static class WebExtensions
    {
        public static string ToHtml(this IHeaderDictionary headers)
        {
            string content = HeadersToHtml(headers);
            string html = CloseHtml(content);
            return html;
        }

        private static string HeadersToHtml(IHeaderDictionary headers)
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

        private static string CloseHtml(string content)
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
        private static string ExpandValue(IEnumerable<string> values)
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
