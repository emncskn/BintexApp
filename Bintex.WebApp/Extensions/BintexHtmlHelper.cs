using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bintex.WebApp.Extensions
{
    public static class BintexHtmlHelper
    {
        public static IHtmlContent BSTextBox<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {
          return  htmlHelper.TextBoxFor(expression, new { @class = "form-control" });
        }
    }
}
