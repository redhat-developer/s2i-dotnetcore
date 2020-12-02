using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SchoolBusAPI.Helpers
{
    public class CsvArrayBinder : IModelBinder
    {
        /// <summary>
        /// Converts comma separated values into a typed array.
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // TODO: Fully document this section
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                return Task.FromResult(0);
            }

            var csvString = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (csvString.Equals(ValueProviderResult.None))
            {
                return Task.FromResult(0);
            }

            try
            {
                var elementType = bindingContext.ModelMetadata.ElementType;
                var converter = TypeDescriptor.GetConverter(elementType);

                var defaultValues = csvString.FirstValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => converter.ConvertFromString(x)).ToArray();

                var typedValues = Array.CreateInstance(elementType, defaultValues.Length);

                defaultValues.CopyTo(typedValues, 0);
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, csvString);
                bindingContext.Result = ModelBindingResult.Success(typedValues);
            }
            catch (Exception e)
            {
                // TODO: Return 400 Bad Request response when query value is malformed
                if (e is FormatException && e.InnerException != null)
                {
                    e = ExceptionDispatchInfo.Capture(e.InnerException).SourceException;
                }
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
            }

            return Task.FromResult(0);
        }
    }
}