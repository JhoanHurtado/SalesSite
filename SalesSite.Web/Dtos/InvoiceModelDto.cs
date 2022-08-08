using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalesSite.Web.Dtos
{
    public class InvoiceModelDto
    {
        public InvoiceModelDto()
        {

        }
        public InvoiceDto invoiceDto { get; set; }
        public List<SelectListItem>  clientDtos { get; set; }
        public List<ProductDto>  productDtos { get; set; }
        public ClientDto Client { get; set; }
        public string cliente { get; set; }
        public List<InvoiceDetailsDto>  InvoiceDetails { get; set; }
    }
}
