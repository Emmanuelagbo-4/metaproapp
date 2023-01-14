using System;
using metaproapp.Models.Request;
using metaproapp.Models.Response;
using metaproapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace metaproapp.Controllers
{
    [Route ("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IpaymentsService _paymentsService;

        public PaymentsController(IpaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        /// <summary>
        /// Create Payments
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePayments(CreatePaymentsRequestModel model) 
        {
            var response =  _paymentsService.CreatePayments(model);

            if (response.status)
            {
                
                return Ok(new ApiResponse {message = response.message, data = response.data});
            }

            return BadRequest(new ApiResponse {message = response.message, errors = "failed to create payments"});
        }

        /// <summary>
        /// Get All Payments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var response = _paymentsService.GetAllPayments();

            if (response.status)
            {
               return Ok(new ApiResponse {message = response.message, data = response.data}); 
            }
            return BadRequest(new ApiResponse {message = response.message, errors = "failed to get all payments"});
        }
        
        /// <summary>
        /// Get Payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPaymentById(long id)
        {
            var response = _paymentsService.GetPaymentById(id);

            if (response.status)
            {
               return Ok(new ApiResponse {message = response.message, data = response.data}); 
            }
            return BadRequest(new ApiResponse {message = response.message, errors=response.message});
        }

        /// <summary>
        /// Delete Payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>    
        [HttpDelete]
         public async Task<IActionResult> DeletePayment(long id) 
        {
            var response =  _paymentsService.DeletePayment(id);

            if (response.status)
            {
                
                return Ok(new ApiResponse {message = response.message, data = response.data});
            }

            return BadRequest(new ApiResponse {message = response.message, errors = "failed to delete payments"});
        }

    }
}

//AyoLawal