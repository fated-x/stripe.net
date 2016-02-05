using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Stripe
{
  public class StripeAddressOptions
  {
    [JsonProperty("legal_entity[address][city]")]
    public string City { get; set; }

    [JsonProperty("legal_entity[address][country]")]
    public string Country { get; set; }

    [JsonProperty("legal_entity[address][line1]")]
    public string Line1 { get; set; }

    [JsonProperty("legal_entity[address][line2]")]
    public string Line2 { get; set; }

    [JsonProperty("legal_entity[address][postal_code]")]
    public string PostalCode { get; set; }

    [JsonProperty("legal_entity[address][state]")]
    public string State { get; set; }
  }
}
