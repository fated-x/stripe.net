using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Stripe.Infrastructure;
using System.Text.RegularExpressions;

namespace Stripe
{
  internal static class ParameterBuilder
  {
    public static string ApplyAllParameters(this StripeService service, object obj, string url, bool isListMethod)
    {
      string newUrl = url;

      if (obj != null)
      {
        foreach (var property in obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
        {
          var value = property.GetValue(obj, null);
          if (value == null) continue;

          foreach (var attribute in property.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
          {
            if (String.Compare(attribute.PropertyName, "metadata", StringComparison.OrdinalIgnoreCase) == 0)
            {
              var metadata = (Dictionary<string, string>)value;

              newUrl = metadata.Keys.Aggregate(newUrl, (current, key) => ApplyParameterToUrl(current, $"metadata[{key}]", metadata[key]));
            }
            else if (property.PropertyType == typeof(StripeDateFilter))
            {
              var filter = (StripeDateFilter)value;

              if (filter.EqualTo.HasValue)
                newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName, filter.EqualTo.Value.ConvertDateTimeToEpoch().ToString());
              else
                  if (filter.LessThan.HasValue)
                newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lt]", filter.LessThan.Value.ConvertDateTimeToEpoch().ToString());

              if (filter.LessThanOrEqual.HasValue)
                newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lte]", filter.LessThanOrEqual.Value.ConvertDateTimeToEpoch().ToString());

              if (filter.GreaterThan.HasValue)
                newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gt]", filter.GreaterThan.Value.ConvertDateTimeToEpoch().ToString());

              if (filter.GreaterThanOrEqual.HasValue)
                newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gte]", filter.GreaterThanOrEqual.Value.ConvertDateTimeToEpoch().ToString());
            }
            else if (property.PropertyType == typeof(StripeBankAccountOptions))
            {
              var bankAccountOptions = (StripeBankAccountOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, bankAccountOptions);
            }
            else if (property.PropertyType == typeof(StripeCreditCardOptions))
            {
              var creditCardOptions = (StripeCreditCardOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, creditCardOptions);
            }
            else if (property.PropertyType == typeof(StripeSourceOptions))
            {
              var stripeSourceOptions = (StripeSourceOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeSourceOptions);
            }
            else if (property.PropertyType == typeof(StripeEvidenceOptions))
            {
              var stripeEvidenceOptions = (StripeEvidenceOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeEvidenceOptions);
            }
            else if (property.PropertyType == typeof(StripeExternalAccountOptions))
            {
              var stripeExternalAccountOptions = (StripeExternalAccountOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeExternalAccountOptions);
            }
            else if (property.PropertyType == typeof(StripeLegalEntityOptions))
            {
              var stripeLegalEntityOptions = (StripeLegalEntityOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeLegalEntityOptions);
            }
            else if (property.PropertyType == typeof(StripeTosAcceptanceOptions))
            {
              var stripeTosAcceptanceOptions = (StripeTosAcceptanceOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeTosAcceptanceOptions);
            }
            else if (property.PropertyType == typeof(StripeTransferScheduleOptions))
            {
              var stripeTransferScheduleOptions = (StripeTransferScheduleOptions)value;
              newUrl = ApplyNestedObjectProperties(newUrl, stripeTransferScheduleOptions);
            }
            else
            {
              newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName, value.ToString());
            }
          }
        }
      }

      if (service != null)
      {
        var propertiesToExpand = service.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.Name.StartsWith("Expand") && p.PropertyType == typeof(bool))
            .Where(p => (bool)p.GetValue(service, null))
            .Select(p => p.Name);

        foreach (var propertyName in propertiesToExpand)
        {
          string expandPropertyName = propertyName.Substring("Expand".Length).Replace("_", ".");
          expandPropertyName = Regex.Replace(expandPropertyName, "([a-z])([A-Z])", "$1_$2").ToLower();

          if (isListMethod)
          {
            expandPropertyName = "data." + expandPropertyName;
          }

          newUrl = ApplyParameterToUrl(newUrl, "expand[]", expandPropertyName);
        }
      }

      return newUrl;
    }

    public static string ApplyParameterToUrl(string url, string argument, string value)
    {
      var token = "&";

      if (!url.Contains("?"))
        token = "?";

      return $"{url}{token}{argument}={HttpUtility.UrlEncode(value)}";
    }

    private static string ApplyNestedObjectProperties(string newUrl, object nestedObject)
    {
      foreach (var prop in nestedObject.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
      {
        var val = prop.GetValue(nestedObject, null);
        if (val == null) continue;

        if (prop.PropertyType == typeof (StripeDobOptions))
        {
          var stripeDobOptions = (StripeDobOptions) val;
          newUrl = ApplyNestedObjectProperties(newUrl, stripeDobOptions);
        }
        else if (prop.PropertyType == typeof(StripeAddressOptions))
        {
          var stripeAddressOptions = (StripeAddressOptions)val;
          newUrl = ApplyNestedObjectProperties(newUrl, stripeAddressOptions);
        }
        else
        {
          foreach (var attr in prop.GetCustomAttributes(typeof (JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
          {
            newUrl = ApplyParameterToUrl(newUrl, attr.PropertyName, val.ToString());
          }
        }
      }

      return newUrl;
    }
  }
}
