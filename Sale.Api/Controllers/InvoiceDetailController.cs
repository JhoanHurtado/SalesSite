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
    public class InvoiceDetailController : ControllerBase
    {
        private IInvoiceDetail _invoiceDetail;
        private readonly IMapper _mapper;

        public InvoiceDetailController(IInvoiceDetail invoiceDetail, IMapper mapper)
        {
            _invoiceDetail = invoiceDetail;
            _mapper = mapper;
        }
        // GETT api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<InvoiceDetailDto>>> Get()
        {
            try
            {
                var details = await _invoiceDetail.Get();
                var InvoiceDetailDto = _mapper.Map<List<InvoiceDetailDto>>(details);
                return BusinessResult<List<InvoiceDetailDto>>.Sucess(InvoiceDetailDto, "Lista de detalles de factura");
            }

            catch (Exception ex)
            {
                return BusinessResult<List<InvoiceDetailDto>>.Issue(null, "Hubo un error al cargar los datos de detalles de factura");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<InvoiceDetailDto>>> Get(string Filtro)
        {
            try
            {
                int filterId = Filtro.All(char.IsDigit) ? Convert.ToInt32(Filtro) : 0;
                var details = await _invoiceDetail.Find(x => x.InvoiceId == filterId);
                var detailsDto = _mapper.Map<List<InvoiceDetailDto>>(details);

                if (details == null || details.Count == 0)
                {
                    return BusinessResult<List<InvoiceDetailDto>>.Sucess(detailsDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<InvoiceDetailDto>>.Sucess(detailsDto, "Detalles de factura encontrados");

            }
            catch (Exception ex)
            {
                return BusinessResult<List<InvoiceDetailDto>>.Issue(null, "Hubo un error al consultar los detalle de factura");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<InvoiceDetailDto>> Post(InvoiceDetailDto InvoiceDetailDto)
        {
            try
            {
                var invo = _mapper.Map<InvoiceDetail>(InvoiceDetailDto);

                var newInvoice = await _invoiceDetail.Add(invo);

                if (newInvoice == null)
                {
                    return BusinessResult<InvoiceDetailDto>.Issue(null, "Hubo un error al registrar el de talle de factura");
                }
                var newInvoiceDetailDto = _mapper.Map<InvoiceDetailDto>(newInvoice);
                return BusinessResult<InvoiceDetailDto>.Sucess(newInvoiceDetailDto, "detalle de factura agregado con exito");

            }

            catch (Exception ex)
            {
                return BusinessResult<InvoiceDetailDto>.Issue(null, "Hubo un error al registrar el detale de factura");
            }
        }
    }
}
