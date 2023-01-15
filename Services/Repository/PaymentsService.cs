using System;
using metaproapp.Data;
using metaproapp.Entities;
using metaproapp.Models.Request;
using metaproapp.Models.Response;
using metaproapp.Services.Interfaces;

namespace metaproapp.Services.Repository
{
    public class PaymentsService : IpaymentsService
    {
        private readonly IGenericRepository<Payment> _paymentRepo;
       
        public PaymentsService(IGenericRepository<Payment> paymentRepo)
        {
           
            _paymentRepo = paymentRepo;
        }
        public ServiceResponse CreatePayments(CreatePaymentsRequestModel model)
        {
            var paymentsObj = new Payment
            {
                AccountName = model.AccountName,
                Amount = model.Amount,
                AccountNumber = model.AccountNumber,
                PaymentDesc = model.PaymentDesc,
                DateCreated = DateTime.Now
            };
            
             bool status = _paymentRepo.Insert(paymentsObj) > 0 ? true : false;

            if (status)
            {
                return new ServiceResponse {status = true, message = "Created Payments successfullly", data = paymentsObj};
            }

            return new ServiceResponse {status = false, message = "failed to create payments"};

        }

        public ServiceResponse DeletePayment(long id)
        {
             bool status = _paymentRepo.Delete(id);

            if (status)
            {
                return new ServiceResponse {status = true, message = "Selected Payment Deleted Successfully successfullly"};
            }

            return new ServiceResponse {status = false, message = "failed to delete payment, please try again"};


        }

        public ServiceResponse GetPaymentById(long id)
        {
             
            var payment = _paymentRepo.Get(id);
            
            if (payment!=null)
            {
                return new ServiceResponse {status = true, message = "Fetched Payment successfullly", data = payment};
            }
            return new ServiceResponse {status = false, message = $"Payment with id {id} does not exist"};
        }

        public ServiceResponse GetAllPayments()
        {
            var payments = _paymentRepo.GetAll<Payments>();
            if (payments!=null) 
            {
                return new ServiceResponse {status = true, message = "Fetched Payment Successfully", data = payments};

            }

            return new ServiceResponse {status = false, message ="Failed to fetch payments"};
        }
    }
}
