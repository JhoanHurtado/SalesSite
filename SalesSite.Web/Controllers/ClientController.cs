using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesSite.Web.Dtos;
using SalesSite.Web.Interface;
using SalesSite.Web.Models;

namespace SalesSite.Web.Controllers
{
    public class ClientController : Controller
    {
        private IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var cl = _clientService.GetApi();
            var clientsDto = _mapper.Map<List<ClientDto>>(cl.result);
            return View(clientsDto);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var clientDto = new ClientDto();
            var p = _clientService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                clientDto = _mapper.Map<ClientDto>(p.result.FirstOrDefault());

            }
            return View(clientDto);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentificationCard,Name,LastName,PhoneNumber")] ClientDto clientDto)
        {
            if (ModelState.IsValid)
            {
                var clientDto1 = new ClientDto();
                var result = _clientService.PostApi(_mapper.Map<Client>(clientDto));
                if (result.isSuccess)
                {
                    clientDto1 = _mapper.Map<ClientDto>(result.result);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var clientDto = new ClientDto();
            var p = _clientService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                clientDto = _mapper.Map<ClientDto>(p.result.FirstOrDefault());

            }
            return View(clientDto);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentificationCard,Name,LastName,PhoneNumber")] ClientDto clientDto)
        {
            if (id != clientDto.Id)
            {
                return NotFound();
            }
            var clientDto1 = new ClientDto();
            var result = _clientService.PutApi(_mapper.Map<Client>(clientDto));
            if (result.isSuccess)
            {
                clientDto1 = _mapper.Map<ClientDto>(result.result);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var clientDto = new ClientDto();
            var p = _clientService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                clientDto = _mapper.Map<ClientDto>(p.result.FirstOrDefault());

            }
            return View(clientDto);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientDto = new ClientDto();
            var clie = _clientService.DeleteApi(id);
            if (clie.isSuccess)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
