namespace AssignmentCityTech.Models
{
    public class VendorModel
    {
        public long? Id { get; set; }
        public string VendorCode {  get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        public string EmailId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string VATNo { get; set; }
        public long? PaymentTermsDayId { get; set; }
        public string PaymentTermsDayName { get; set; }
        public string strContractStartDate { get; set; }
        public string strContractEndDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public bool? CompanySignedAgreement { get; set; }
    }
    
}
