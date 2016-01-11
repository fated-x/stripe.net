using System.Collections.Generic;

namespace Stripe
{
  public class StripeRefundService : StripeService
  {
    public StripeRefundService(string apiKey = null) : base(apiKey) { }

    public bool ExpandCharge { get; set; }
    public bool ExpandCharge_ApplicationFee { get; set; }
    public bool ExpandCharge_Refunds_Data_BalanceTransaction { get; set; }
    public bool ExpandBalanceTransaction { get; set; }

    public virtual StripeRefund Create(string chargeId, StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}/refunds";
      url = this.ApplyAllParameters(createOptions, url, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeRefund>.MapFromJson(response);
    }

    public virtual StripeRefund Get(string chargeId, string refundId, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}/refunds/{refundId}";
      url = this.ApplyAllParameters(null, url, false);

      var response = Requestor.GetString(url, requestOptions);

      return Mapper<StripeRefund>.MapFromJson(response);
    }

    public virtual StripeRefund Update(string chargeId, string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}/refunds/{refundId}";
      url = this.ApplyAllParameters(updateOptions, url, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeRefund>.MapFromJson(response);
    }

    public virtual IEnumerable<StripeRefund> List(string chargeId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Charges}/{chargeId}/refunds";
      url = this.ApplyAllParameters(listOptions, url, true);

      var response = Requestor.GetString(url, requestOptions);

      return Mapper<StripeRefund>.MapCollectionFromJson(response);
    }
  }
}
