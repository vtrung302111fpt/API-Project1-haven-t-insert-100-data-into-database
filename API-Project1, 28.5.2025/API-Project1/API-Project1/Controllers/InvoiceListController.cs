using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using API_Project1.Interfaces;
using API_Project1.Entities; // Import interface của LoginService

namespace API_Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceListController : ControllerBase
    {
        private readonly IInvoiceListService _invoiceListService;

        public InvoiceListController(IInvoiceListService invoiceListService)
        {
            _invoiceListService = invoiceListService;
        }
        [HttpGet(Name = "get-invoice-list")]
        public async Task<IActionResult> GetInvoiceListAsync([FromQuery] int currentPage = 0)
        {
            try
            {
                var raw = await _invoiceListService.GetDataListAsync(currentPage);
                //chuyển qua dùng hàm lọc data có sẵn, không dùng hàm full response nữa

                using var doc = JsonDocument.Parse(raw);
                var root = doc.RootElement;

                var data = root.Clone();  // root chính là mảng data 

                // Gọi hàm ConvertJsonToInvoiceList từ service
                //List<InvoiceListEntity> invoices = _invoiceListService.ConvertJsonToInvoiceList(data);

                //await _invoiceListService.SaveListToDatabaseAsync(invoices);

                var fullList = await _invoiceListService.GetFullDataListAsync();
                await _invoiceListService.SaveListToDatabaseAsync(fullList);



                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}


