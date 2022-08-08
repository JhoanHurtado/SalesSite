using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Entitie.Entities;
using Sale.Interface.Interface;
using Sale.Utility.Utility;

namespace Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoice _invoice;
        private IInvoiceDetail _invoiceDetail;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoice invoice, IInvoiceDetail invoiceDetail, IMapper mapper)
        {
            _invoice = invoice;
            _invoiceDetail = invoiceDetail;
            _mapper = mapper;
        }
        // GETT api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<InvoiceDto>>> Get()
        {
            try
            {
                var invoices = await _invoice.Get();
                var invoiceDto = _mapper.Map<List<InvoiceDto>>(invoices);
                return BusinessResult<List<InvoiceDto>>.Sucess(invoiceDto, "Lista de facturas");
            }
            catch (Exception ex)
            {
                return BusinessResult<List<InvoiceDto>>.Issue(null, "Hubo un error al cargar los datos de facturas");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<InvoiceDto>>> Get(string Filtro)
        {


            try
            {
                int filterId = Filtro.All(char.IsDigit) ? Convert.ToInt32(Filtro) : 0;
                var invoices = await _invoice.Find(x => x.Id == filterId);
                var invoicesDto = _mapper.Map<List<InvoiceDto>>(invoices);

                if (invoices == null || invoices.Count == 0)
                {
                    return BusinessResult<List<InvoiceDto>>.Sucess(invoicesDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<InvoiceDto>>.Sucess(invoicesDto, "facturas encontrados");

            }
            catch (Exception ex)
            {
                return BusinessResult<List<InvoiceDto>>.Issue(null, "Hubo un error al consultar la factura");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<InvoiceDto>> Post(InvoiceDto InvoiceDto)
        {
            try
            {
                var invo = _mapper.Map<Invoice>(InvoiceDto);

                var newInvoice = await _invoice.Add(invo);

                if (newInvoice == null)
                {
                    return BusinessResult<InvoiceDto>.Issue(null, "Hubo un error al registrar el factura");
                }
                var newInvoiceDto = _mapper.Map<InvoiceDto>(newInvoice);
                return BusinessResult<InvoiceDto>.Sucess(newInvoiceDto, "factura agregada con exito");

            }
            catch (Exception ex)
            {
                return BusinessResult<InvoiceDto>.Issue(null, "Hubo un error al registrar la factura");
            }
        }
    }
}
