using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalesSite.Web.Dtos;
using SalesSite.Web.Interface;
using SalesSite.Web.Models;

namespace SalesSite.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceService _invoiceService;
        private IInvoiceDetailService _invoiceDetailService;
        private IClientService _clientService;
        private IProductService _productService;


        private readonly IMapper _mapper;
        public InvoiceController(IInvoiceService invoiceService, IMapper mapper, IClientService clientService, IProductService productService, IInvoiceDetailService invoiceDetailService)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _clientService = clientService;
            _productService = productService;
            _invoiceDetailService = invoiceDetailService;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var inv = _invoiceService.GetApi();
            var invoiceDto = _mapper.Map<List<InvoiceDto>>(inv.result);

            return View(invoiceDto);
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var invoiceDto = new InvoiceDto();
            var invoicesDetailDto = new List<InvoiceDetailsDto>();
            var invoiceModel = new InvoiceModelDto();
            var cliente = new ClientDto();
            var p = _invoiceService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                invoiceDto = _mapper.Map<InvoiceDto>(p.result.FirstOrDefault());
                var de = _invoiceDetailService.GetApi("/" + invoiceDto.Id);
                invoicesDetailDto = _mapper.Map<List<InvoiceDetailsDto>>(de.result);
                var cli = _clientService.GetApi("/" + invoiceDto.ClientId);
                cliente = _mapper.Map<ClientDto>(cli.result.FirstOrDefault());

            }
            invoiceModel.invoiceDto = invoiceDto;
            invoiceModel.InvoiceDetails = invoicesDetailDto;
            invoiceModel.Client = cliente;
            invoiceModel.cliente = cliente.Name + " " + cliente.LastName;
            return View(invoiceModel);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            var cl = _clientService.GetApi();
            var clientsDto = _mapper.Map<List<ClientDto>>(cl.result);

            var prod = _productService.GetApi();
            var productsDto = _mapper.Map<List<ProductDto>>(prod.result);

            var invoiceModelDto = new InvoiceModelDto();

            invoiceModelDto.productDtos = productsDto;
            invoiceModelDto.invoiceDto = new InvoiceDto();

            invoiceModelDto.clientDtos = clientsDto.Select(c => new SelectListItem
            {
                Value = Convert.ToString(c.Id),
                Text = c.Name +" "+ c.LastName
            }).ToList();

            return View(invoiceModelDto);
        }

        // POST: Invoice/Create
        [HttpPost]
        public IActionResult Create(InvoiceDto invoiceDto)
        {
            string jsonString = "";
            if (ModelState.IsValid)
            {
                var result = _invoiceService.PostApi(_mapper.Map<Invoice>(invoiceDto));
                var invoiceDto1 = _mapper.Map<InvoiceDto>(result.result);

                jsonString = JsonConvert.SerializeObject(invoiceDto1);
                return Ok(jsonString);
            }
            return null;        
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var InvoiceDto = new InvoiceDto();
            var p = _invoiceService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                InvoiceDto = _mapper.Map<InvoiceDto>(p.result.FirstOrDefault());

            }
            return View(InvoiceDto);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuyDate,Total,TotalProducts,ClientId,UserId")] InvoiceDto invoiceDto)
        {
            if (id != invoiceDto.Id)
            {
                return NotFound();
            }

            var invoiceDto1 = new InvoiceDto();
            var result = _invoiceService.PutApi(_mapper.Map<Invoice>(invoiceDto));
            if (result.isSuccess)
            {
                invoiceDto1 = _mapper.Map<InvoiceDto>(result.result);
            }
            return RedirectToAction("Index");
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var InvoiceDto = new InvoiceDto();
            var p = _invoiceService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                InvoiceDto = _mapper.Map<InvoiceDto>(p.result.FirstOrDefault());

            }
            return View(InvoiceDto);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var InvoiceDto = new InvoiceDto();
            var invo = _invoiceService.DeleteApi(id);
            if (invo.isSuccess)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
