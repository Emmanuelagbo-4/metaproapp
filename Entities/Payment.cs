using metaproapp.Data;

namespace metaproapp.Entities
{
    public class Payment : BaseEntity
    {
       
        public string AccountName { get; set; }
        public double AccountNumber { get; set; }
        public double Amount { get; set; }
        public string PaymentDesc { get; set; }

    }
}