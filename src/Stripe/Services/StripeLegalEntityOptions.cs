using Newtonsoft.Json;

namespace Stripe
{
  public class StripeLegalEntityOptions
  {
    [JsonProperty("legal_entity[business_name]")]
    public string BusinessName { get; set; }

    [JsonProperty("legal_entity[business_tax_id]")]
    public int? BusinessTaxId { get; set; }

    [JsonProperty("legal_entity[business_vat_id]")]
    public int? BusinessVatId { get; set; }

    [JsonProperty("legal_entity[first_name]")]
    public string FirstName { get; set; }

    [JsonProperty("legal_entity[last_name]")]
    public string LastName { get; set; }

    [JsonProperty("legal_entity[personal_id_number]")]
    public int? PersonalIdNumber { get; set; }

    [JsonProperty("legal_entity[ssn_last_4]")]
    public int? SsnLastFour { get; set; }

    [JsonProperty("legal_entity[type]")]
    public string Type { get; set; }

    // AdditionalOwners (additional_owners)

    // Address (address)

    // DateOfBirth (dob)

    // PersonalAddress (personal_address)

    // Verification (verification)
  }
}