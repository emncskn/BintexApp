using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bintex.WebApp.Extensions
{
    public static class BintexHtmlHelper
    {
        public static IHtmlContent BSTextBox<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {
          return  htmlHelper.TextBoxFor(expression, new { @class = "form-control" });
        }
        public static IHtmlContent BSDisplayFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<label for=\"{expression.Name}\" class=\"col-sm-2 col-form-label\">");
            builder.Append(htmlHelper.DisplayNameFor(expression));
            builder.Append("</label>");

            return new HtmlString(builder.ToString());
        }
    }
}
