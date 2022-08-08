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
    public class InvoiceDetailController : Controller
    {
        private IInvoiceDetailService _invoiceDetailService;


        private readonly IMapper _mapper;
        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService, IMapper mapper)
        {
            _invoiceDetailService = invoiceDetailService;
            _mapper = mapper;
        }

        // POST: Invoice/Create
        [HttpPost]

        public IActionResult Create(InvoiceDetailsDto invoiceDetailsDto)
        {
            string jsonString = "";
            if (ModelState.IsValid)
            {
                var result = _invoiceDetailService.PostApi(_mapper.Map<InvoiceDetail>(invoiceDetailsDto));
                var invoiceDto1 = _mapper.Map<InvoiceDetailsDto>(result.result);
                jsonString = JsonConvert.SerializeObject(invoiceDto1);
                return RedirectToAction("Index", "Invoice");
            }
            return null;        
        }

    }
}
