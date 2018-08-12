using AutoMapper;
using DatPQShop.Model.Models;
using DatPQShop.Service;
using DatPQShop.Web.Infrastructure.Core;
using DatPQShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatPQShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) 
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable< ProductCategoryViewModel >>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}