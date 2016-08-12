using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Stripe
{
  public class StripeChargeService : StripeService
  {
    public StripeChargeService(string apiKey = null) : base(apiKey) { }

    public bool ExpandApplicationFee { get; set; }
    public bool ExpandBalanceTransaction { get; set; }
    public bool ExpandCustomer { get; set; }
    public bool ExpandInvoice { get; set; }
    public bool ExpandRefunds_Data_BalanceTransaction { get; set; }
    public bool ExpandDispute_Evidence_CustomerCommunication { get; set; }
    public bool ExpandDispute_Evidence_Receipt{ get; set; }
    public bool ExpandDispute_Evidence_ServiceDocumentation{ get; set; }
    public bool ExpandDispute_Evidence_UncategorizedFile { get; set; }

    public virtual StripeCharge Create(StripeChargeCreateOptions createOptions, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = this.ApplyAllParameters(createOptions, Urls.Charges, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeCharge>.MapFromJson(response);
    }

    public virtual StripeCharge Update(string chargeId, StripeChargeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}";
      url = this.ApplyAllParameters(updateOptions, url, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeCharge>.MapFromJson(response);
    }

    public virtual StripeCharge Get(string chargeId, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}";
      url = this.ApplyAllParameters(null, url, false);

      var response = Requestor.GetString(url, requestOptions);

      return Mapper<StripeCharge>.MapFromJson(response);
    }

    public virtual IEnumerable<StripeCharge> List(StripeChargeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);
      if (listOptions != null && listOptions.FetchAll)
      {
        listOptions.EndingBefore = null;
        listOptions.StartingAfter = null;
        listOptions.Limit = 100;
      }

      var charges = new List<StripeCharge>();
      var hasMore = true;
      do
      {
        var url = Urls.Charges;
        url = this.ApplyAllParameters(listOptions, url, true);

        var response = Requestor.GetString(url, requestOptions);
        charges.AddRange(Mapper<StripeCharge>.MapCollectionFromJson(response).ToList());

        var jObject = JObject.Parse(response);
        if ((bool)jObject.SelectToken("has_more") && listOptions != null && listOptions.FetchAll)
        {
          listOptions.EndingBefore = null;
          listOptions.StartingAfter = charges.Last().ChargeID;
          listOptions.Limit = 100;
        }
        else
        {
          hasMore = false;
        }
      } while (hasMore);

        return charges;
    }

    public virtual StripeCharge Capture(string chargeId, int? captureAmount = null, int? applicationFee = null, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}/capture";
      url = this.ApplyAllParameters(null, url, false);

      if (captureAmount.HasValue)
        url = ParameterBuilder.ApplyParameterToUrl(url, "amount", captureAmount.Value.ToString());
      if (applicationFee.HasValue)
        url = ParameterBuilder.ApplyParameterToUrl(url, "application_fee", applicationFee.Value.ToString());

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeCharge>.MapFromJson(response);
    }
  }
}