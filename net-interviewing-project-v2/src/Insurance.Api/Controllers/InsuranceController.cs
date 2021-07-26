using System;
using System.Threading.Tasks;
using Insurance.Api.Models;
using Insurance.Domain.Entities.Utility.Exceptions;
using Insurance.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Insurance.Api.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        [Route("api/insurance/product/{productId}")]
        public async Task<IActionResult> CalculateProductInsurance(int productId)
        {
            var productInsuranceValue = await _insuranceService.CalculateProductInsuranceValue(productId);

            var productInsuranceResponse = new ProductInsuranceResponse()
            {
                ProductId = productId,
                InsuranceValue = productInsuranceValue
            };

            return Ok(productInsuranceResponse);

        }

        [HttpPost]
        [Route("api/insurance/order")]
        public async Task<IActionResult> CalculateOrderInsurance(OrderInsuranceRequest request)
        {
            try
            {
                var orderInsuranceValue = await _insuranceService.CalculateOrderInsuranceValue(request.ProductIds);

                var productInsuranceResponse = new OrderInsuranceResponse()
                {
                    OrderId = request.OrderId,
                    OrderInsuranceValue = orderInsuranceValue,
                };

                return Ok(productInsuranceResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
