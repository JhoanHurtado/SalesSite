using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Dto.Dtos;
using Product.Interface.Interfaces;
using Product.Utility.Utility;
using pro = Product.Entitie.Entities;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _iProduct;
        private readonly IMapper _mapper;

        public ProductController(IProduct product, IMapper mapper)
        {
            _iProduct = product;
            _mapper = mapper;
        }

        // GETT api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<ProductDto>>> Get()
        {
            try
            {
                var products = await _iProduct.Get();
                var productsDto = _mapper.Map<List<ProductDto>>(products);
                return BusinessResult<List<ProductDto>>.Sucess(productsDto, "Lista de productos");
            }
            catch (Exception ex)
            {
                return BusinessResult<List<ProductDto>>.Issue(null, "Hubo un error al cargar los datos de productos");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<ProductDto>>> Get(string Filtro)
        {


            try
            {
                int filterId = Filtro.All(char.IsDigit) ? Convert.ToInt32(Filtro) : 0;
                var products = await _iProduct.Find(x => x.Name.Contains(Filtro) || x.Id == filterId);
                var productsDto = _mapper.Map<List<ProductDto>>(products);

                if (products == null || products.Count == 0)
                {
                    return BusinessResult<List<ProductDto>>.Sucess(productsDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<ProductDto>>.Sucess(productsDto, "Productos encontrados");

            }
            catch (Exception ex)
            {
                return BusinessResult<List<ProductDto>>.Issue(null, "Hubo un error al consultar los producto");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<ProductDto>> Post(ProductPostDto productDto)
        {
            try
            {
                var produ = _mapper.Map<pro.Product>(productDto);

                var newProduct = await _iProduct.Add(produ);

                if (newProduct == null)
                {
                    return BusinessResult<ProductDto>.Issue(null, "Hubo un error al registrar el producto");
                }
                var newProductDto = _mapper.Map<ProductDto>(newProduct);
                return BusinessResult<ProductDto>.Sucess(newProductDto, "Producto agregado con exito");

            }
            catch (Exception ex)
            {
                return BusinessResult<ProductDto>.Issue(null, "Hubo un error al registrar el producto");
            }
        }

        // PUT api/<ValuesController>
        [HttpPut]
        public async Task<BusinessResult<ProductDto>> Put(ProductDto productDto)
        {
            try
            {
                var produ = _mapper.Map<pro.Product>(productDto);

                var updateProduct = await _iProduct.Update(produ);

                if (!updateProduct)
                {
                    return BusinessResult<ProductDto>.Issue(null, "Hubo un error al actualizar el producto");
                }
                return BusinessResult<ProductDto>.Sucess(productDto, "Producto actualizado con exito");

            }
            catch (Exception ex)
            {
                return BusinessResult<ProductDto>.Issue(null, "Hubo un error al axtualizar el producto");
            }
        }

        // GETT api/<ValuesController>/
        [HttpDelete("{id}")]
        public async Task<BusinessResult<ProductDto>> Delete(int id)
        {
            try
            {
                var delete = await _iProduct.Delete(id);
                if (delete)
                {
                    return BusinessResult<ProductDto>.Sucess(null, "Producto eliminado");
                }
                return BusinessResult<ProductDto>.Sucess(null, "No se pudo eliminar el producto");

            }
            catch (Exception ex)
            {
                return BusinessResult<ProductDto>.Issue(null, "Hubo un error al eliminar el producto");
            }
        }
    }
}
