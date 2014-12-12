using AdventureWorks.DataAccess.Interfaces;
using AdventureWorks.DomainModels;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventureWorks.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductSummary> GetProductSummaries()
        {
            var productSummaries = new List<ProductSummary>();

            var context = new AdventureWorks2014Entities();

            var products = context.Products.Where(o => o.FinishedGoodsFlag);

            foreach (var product in products)
            {
                var productSummary = new ProductSummary();

                productSummary.ListPrice = product.ListPrice;
                productSummary.ProductId = product.ProductID;
                productSummary.ProductName = product.Name;

                var ppp = product.ProductProductPhotoes.FirstOrDefault();

                if (ppp != null)
                    productSummary.ProductPhotoId = product.ProductProductPhotoes.First().ProductPhotoID;

                productSummaries.Add(productSummary);
            }

            return productSummaries;   
        }

        public byte[] GetProductPhoto(int productPhotoId)
        {
            var context = new AdventureWorks2014Entities();

            var productPhoto = context.ProductPhotoes.FirstOrDefault(o => o.ProductPhotoID == productPhotoId);

            if (productPhoto != null)
                return productPhoto.LargePhoto;

            return null;
        }

        public byte[] GetProductThumbnailPhoto(int productPhotoId)
        {
            var context = new AdventureWorks2014Entities();

            var productPhoto = context.ProductPhotoes.FirstOrDefault(o => o.ProductPhotoID == productPhotoId);

            if (productPhoto != null)
                return productPhoto.ThumbNailPhoto;

            return null;
        }

        public ProductDetail GetProductDetail(int productId)
        {
            var productDetail = new ProductDetail();

            var context = new AdventureWorks2014Entities();

            var product = context.Products.FirstOrDefault(o => o.ProductID == productId);

            if (product != null)
            {
                productDetail.ListPrice = product.ListPrice;
                productDetail.ProductId = product.ProductID;
                productDetail.ProductName = product.Name;

                var pmpdc = product.ProductModel.ProductModelProductDescriptionCultures
                                                .FirstOrDefault(o => o.Culture.Name == "en");

                if (pmpdc != null)
                    productDetail.ProductDescription = pmpdc.ProductDescription.Description;

                var ppp = product.ProductProductPhotoes.FirstOrDefault();

                if (ppp != null)
                    productDetail.ProductPhotoId = product.ProductProductPhotoes.First().ProductPhotoID;
            }

            return productDetail;
        }
    }
}
