using AutoMapper;
using Client.Dto.Dtos;
using Client.Interface.interfaces;
using Client.Utility.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cli = Client.Entities.Entities;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClient _iClient;
        private readonly IMapper _mapper;

        public ClientController(IClient client, IMapper mapper)
        {
            _iClient = client;
            _mapper = mapper;
        }

        // GETT api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<ClientDto>>> Get()
        {
            try
            {
                var products = await _iClient.Get();
                var productsDto = _mapper.Map<List<ClientDto>>(products);
                return BusinessResult<List<ClientDto>>.Sucess(productsDto, "Lista de clientes");
            }
            catch (Exception ex)
            {
                return BusinessResult<List<ClientDto>>.Issue(null, "Hubo un error al cargar los datos de clientes");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<ClientDto>>> Get(string Filtro)
        {


            try
            {
                int filterId = Filtro.All(char.IsDigit) ? Convert.ToInt32(Filtro) : 0;
                var clients = await _iClient.Find(x => x.Name.Contains(Filtro) || x.Id == filterId);

                if (clients == null || clients.Count == 0)
                {
                    return BusinessResult<List<ClientDto>>.Sucess(null, "Cero resultados encontrados");
                }
                var clientsDto = _mapper.Map<List<ClientDto>>(clients);
                return BusinessResult<List<ClientDto>>.Sucess(clientsDto, "Clientes encontrados");

            }
            catch (Exception ex)
            {
                return BusinessResult<List<ClientDto>>.Issue(null, "Hubo un error al consultar los clientes");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<ClientDto>> Post(ClientPostDto ClientDto)
        {
            try
            {
                var clien = _mapper.Map<cli.Client>(ClientDto);

                var newClient = await _iClient.Add(clien);

                if (newClient == null)
                {
                    return BusinessResult<ClientDto>.Issue(null, "Hubo un error al registrar el cliennte");
                }
                var newClientDto = _mapper.Map<ClientDto>(newClient);
                return BusinessResult<ClientDto>.Sucess(newClientDto, "Cliente agregado con exito");

            }
            catch (Exception ex)
            {
                return BusinessResult<ClientDto>.Issue(null, "Hubo un error al registrar el cliente");
            }
        }

        // PUT api/<ValuesController>
        [HttpPut]
        public async Task<BusinessResult<ClientDto>> Put(ClientDto ClientDto)
        {
            try
            {
                var clie = _mapper.Map<cli.Client>(ClientDto);

                var updateClient = await _iClient.Update(clie);

                if (!updateClient)
                {
                    return BusinessResult<ClientDto>.Issue(null, "Hubo un error al actualizar el cliente");
                }
                return BusinessResult<ClientDto>.Sucess(ClientDto, "Cliente actualizado con exito");

            }
            catch (Exception ex)
            {
                return BusinessResult<ClientDto>.Issue(null, "Hubo un error al axtualizar el cliente");
            }
        }

        // GETT api/<ValuesController>/
        [HttpDelete("{id}")]
        public async Task<BusinessResult<ClientDto>> Delete(int id)
        {
            try
            {
                var delete = await _iClient.Delete(id);
                if (delete)
                {
                    return BusinessResult<ClientDto>.Sucess(null, "Cliente eliminado");
                }
                return BusinessResult<ClientDto>.Sucess(null, "No se pudo eliminar el cliente");

            }
            catch (Exception ex)
            {
                return BusinessResult<ClientDto>.Issue(null, "Hubo un error al eliminar el cliente");
            }
        }
    }
}
