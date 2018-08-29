using AutoMapper;
using DatPQShop.Common;
using DatPQShop.Model.Models;
using DatPQShop.Service;
using DatPQShop.Web.Infrastructure.Core;
using DatPQShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DatPQShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
            this._productService = productService;
        }
        // GET: Product
        public ActionResult Detail(int id)
        {
            _productService.IncreaseView(id);
            _productService.Save();
            var productModel = _productService.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(productModel);
            List<string> moreImages = new JavaScriptSerializer().Deserialize<List<string>>(productViewModel.MoreImages);
            ViewBag.MoreImages = moreImages;
            var tagModel = _productService.GetListTagByProductId(id);
            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>,IEnumerable<TagViewModel>>(tagModel);
            var relatedProducts = _productService.GetRelatedProducts(id, 6);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProducts);
            return View(productViewModel);
        }
        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {

            int pageSize = int.Parse(ConfigHelper.GetBykey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.Search(keyword, page, pageSize, out totalRow, sort);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetBykey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Keyword = keyword;
            return View(paginationSet);
        }
        public ActionResult ListProductByTag(string tagId, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetBykey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByTag(tagId, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetBykey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
                
            };
            ViewBag.Tag = Mapper.Map<Tag,TagViewModel>(_productService.GetTagById(tagId));
            return View(paginationSet);
        }
        public ActionResult Category(int id, int page = 1, string sort = "")
        {

            int pageSize = int.Parse(ConfigHelper.GetBykey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow, sort);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetBykey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            var categoryModel = _productCategoryService.GetById(id);
            var categoryViewModel = Mapper.Map<ProductCategory, ProductCategoryViewModel>(categoryModel);
            ViewBag.Category = categoryViewModel;
            return View(paginationSet);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var productViewModel = _productService.GetListProductByName(keyword);
            return Json(
                new
                {
                    data = productViewModel
                }, JsonRequestBehavior.AllowGet
                );
        }
    }
}