using System;

namespace metaproapp.Models.Request
{
    public class CreatePaymentsRequestModel
    {
        public string? AccountName { get; set; } 
        public double AccountNumber { get; set; }
        public double Amount { get; set; }
        public string? PaymentDesc { get; set; }
    }
}
