using AdventureWorks.BusinessLogic.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AdventureWorks.ViewModels;

namespace AdventureWorks.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductHandler _productHandler;

        public ProductController(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        public HttpResponseMessage GetProductSummaries()
        {
            HttpResponseMessage httpResponseMessage;

            try
            {
                var productSummaries = _productHandler.GetProductSummaries().Select(o => new ProductSummary
                    {
                        ListPrice = o.ListPrice,
                        ProductDescription = o.ProductDescription,
                        ProductId = o.ProductId,
                        ProductName = o.ProductName,
                        ProductPhotoId = o.ProductPhotoId
                    });

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, productSummaries.ToList());
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }

            return httpResponseMessage;
        }

        public HttpResponseMessage GetProductPhoto(int productPhotoId)
        {
            HttpResponseMessage httpResponseMessage;

            try
            {
                var photo = _productHandler.GetProductPhoto(productPhotoId);

                var ms = new MemoryStream(photo);
                var sc = new StreamContent(ms);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = sc;
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/gif");
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }

            return httpResponseMessage; 
        }

        public HttpResponseMessage GetProductThumbnailPhoto(int productPhotoId)
        {
            HttpResponseMessage httpResponseMessage;

            try
            {
                var photo = _productHandler.GetProductThumbnailPhoto(productPhotoId);

                var ms = new MemoryStream(photo);
                var sc = new StreamContent(ms);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = sc;
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/gif");
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }

            return httpResponseMessage;
        }

        public HttpResponseMessage GetProductDetail(int productId)
        {
            HttpResponseMessage httpResponseMessage;

            try
            {
                var dmProductDetail = _productHandler.GetProductDetail(productId);
                
                var vmProductDetail= new ProductDetail 
                    {
                        ListPrice = dmProductDetail.ListPrice,
                        ProductDescription = dmProductDetail.ProductDescription,
                        ProductId = dmProductDetail.ProductId,
                        ProductName = dmProductDetail.ProductName,
                        ProductPhotoId = dmProductDetail.ProductPhotoId
                    };

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, vmProductDetail);
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.Message);
            }

            return httpResponseMessage;
        }
    }
}
