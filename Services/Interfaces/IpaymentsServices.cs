using System;
using metaproapp.Models.Request;
using metaproapp.Models.Response;

namespace metaproapp.Services.Interfaces
{
    public interface IpaymentsService
    {
        ServiceResponse CreatePayments(CreatePaymentsRequestModel model);

        ServiceResponse GetAllPayments();

        ServiceResponse GetPaymentById(long id);

        ServiceResponse DeletePayment(long id);
    }
}
