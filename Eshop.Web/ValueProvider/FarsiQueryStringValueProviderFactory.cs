using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Convertors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace Eshop.Web.ValueProvider
{
    public class FarsiQueryStringValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var query = context.ActionContext.HttpContext.Request.Query;
            if (query != null && query.Count > 0)
            {
                var stringValueProvider = new FarsiQueryStringValueProvider(BindingSource.Query, query, CultureInfo.InvariantCulture);
                context.ValueProviders.Insert(0, stringValueProvider);
            }

            return Task.CompletedTask;
        }
    }
}
public class FarsiQueryStringValueProvider : QueryStringValueProvider
{
    public FarsiQueryStringValueProvider(BindingSource bindingSource, IQueryCollection values, CultureInfo culture)
        : base(bindingSource, values, culture)
    {

    }

    public override ValueProviderResult GetValue(string key)
    {
        var result = base.GetValue(key);

        if (result != ValueProviderResult.None)
        {
            var values = result.Values.ToString().ToPersianKafYa();
            result = new ValueProviderResult(new StringValues(values), Culture);
        }

        return result;
    }
}
