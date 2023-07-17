using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Services;
using DotnetWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly Serilog.ILogger _logger;

        public PurchaseController(IPurchaseService purchaseService, Serilog.ILogger logger)
        {
            _purchaseService = purchaseService;
            _logger = logger;
        }

        [HttpPost("CreatePurchase")]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseModel createPurchaseModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var purchase = await _purchaseService.CreatePurchase(createPurchaseModel);

                return Ok(purchase);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("RecoverAllPurchases")]
        public async Task<IActionResult> RecoverAllPurchases()
        {
            try
            {
                var purchases = await _purchaseService.RecoverAllPurchases();

                return Ok(purchases);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
