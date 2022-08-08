using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesSite.Web.Dtos;
using SalesSite.Web.Interface;
using SalesSite.Web.Models;

namespace SalesSite.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService; 
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var p = _productService.GetApi();
            var productsDto = _mapper.Map<List<ProductDto>>(p.result);
            return View(productsDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var productDto = new ProductDto();
            var p = _productService.GetApi("/"+id);
            if (p.result.Count>0)
            {
                productDto = _mapper.Map<ProductDto>(p.result.FirstOrDefault());

            }
            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDto p)
        {
            try
            {
                var productDto = new ProductDto();
                var presult = _productService.PostApi(_mapper.Map<Product>(p));
                if (presult.isSuccess)
                {
                    productDto = _mapper.Map<ProductDto>(presult.result);                    
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var productDto = new ProductDto();
            var p = _productService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                productDto = _mapper.Map<ProductDto>(p.result.FirstOrDefault());

            }
            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductDto p)
        {
            try
            {
                var productDto = new ProductDto();
                var presult = _productService.PutApi(_mapper.Map<Product>(p));
                if (presult.isSuccess)
                {
                    productDto = _mapper.Map<ProductDto>(presult.result);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var productDto = new ProductDto();
            var p = _productService.GetApi("/" + id);
            if (p.result.Count > 0)
            {
                productDto = _mapper.Map<ProductDto>(p.result.FirstOrDefault());

            }
            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var productDto = new ProductDto();
            var prod = _productService.DeleteApi(id);
            if (prod.isSuccess)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
