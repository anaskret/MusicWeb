using MusicWeb.Admin.Models;
using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Extenstions
{
    public static class HtmlExtensions
    {
        public static string Pager(PagerModel model)
        {
            if (model.TotalPages <= 1)
                return "";

            // if more than 1 page
            var html = new StringBuilder();
            string search;
            if (string.IsNullOrEmpty(model.SearchString) && model.UserType == UserType.All)
                search = model.UrlAdress + "/{0}";
            else
                search = model.UrlAdress + "/{0}" + $"/{(int)model.UserType}" + $"/{model.SearchString}";

            search = search.ToLower();
            html.Append(@"<nav aria-label=""..."">");
            html.Append("<ul class='pagination justify-content-end'>");

            #region[Show all the pages]

            if (model.TotalPages <= 5)
            {
                html.Append(String.Format("<li class='page-item " + (model.CurrentPage == 1 ? "disabled active" : "") + "'><a class='page-link' href='"
                    + search + "'>1</a></li>", 1));
                html.Append(String.Format("<li class='page-item " + (model.CurrentPage == 2 ? "disabled active" : "") + "'><a class='page-link' href='"
                    + search + "'>2</a></li>", 2));

                if (model.TotalPages >= 3)
                    html.Append(String.Format("<li class='page-item " + (model.CurrentPage == 3 ? "disabled active" : "") + "'><a class='page-link' href='"
                        + search + "'>3</a></li>", 3));

                if (model.TotalPages >= 4)
                    html.Append(String.Format("<li class='page-item " + (model.CurrentPage == 4 ? "disabled active" : "") + "'><a class='page-link' href='"
                        + search + "'>4</a></li>", 4));

                if (model.TotalPages >= 5)
                    html.Append(String.Format("<li class='page-item " + (model.CurrentPage == 5 ? "disabled active" : "") + "'><a class='page-link' href='"
                        + search + "'>5</a></li>", 5));
            }
            #endregion

            else if (model.TotalPages > 5)
            {
                if (model.CurrentPage < 5)
                {
                    for (var i = 1; i <= model.TotalPages; i++)
                    {
                        html.Append(String.Format("<li class='page-item " + (model.CurrentPage == i ? "disabled active" : "")
                            + "'><a class='page-link' href='" + search + "'>{0}</a></li>", i));
                        if (i == 5) break;
                    }

                    // Last Page with  ..
                    html.Append("<li class='page-item disabled'><a class='page-link' href='#'>...</a></li>");
                    html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.TotalPages));
                }

                else
                {
                    html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", 1));
                    html.Append("<li class='page-item disabled'><a class='page-link' href='#'>...</a></li>");
                    if (model.CurrentPage == model.TotalPages)
                    {
                        html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage - 4));
                        html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage - 3));
                    }
                    else if (model.CurrentPage + 1 == model.TotalPages)
                    {
                        html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage - 3));
                    }

                    html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage - 2));
                    html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage - 1));
                    html.Append(String.Format("<li class='page-item disabled active'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage));

                    if (model.CurrentPage + 1 <= model.TotalPages)
                        html.Append(String.Format("<li class='page-item'><a class='page-link' href='" + search + "'>{0}</a></li>", model.CurrentPage + 1));

                    if (model.CurrentPage + 2 <= model.TotalPages)
                        html.Append(String.Format("<li class='page-item'><a class='page-link active' href='" + search + "'>{0}</a></li>", model.CurrentPage + 2));

                    // still more pages
                    if (model.CurrentPage + 2 < model.TotalPages)
                    {
                        html.Append("<li class='page-item disabled'><a class='page-link' href='#'>...</a></li>");
                        html.Append(String.Format("<li class='page-item'><a class='page-link active' href='" + search + "'>{0}</a></li>", model.TotalPages));
                    }
                }
            }

            html.Append("</ul>");
            html.Append(" </nav>");
            return html.ToString();
        }
    }
}
