using AdventureWorks.BusinessLogic.Interfaces;
using AdventureWorks.DataAccess.Interfaces;
using AdventureWorks.DomainModels;
using System.Collections.Generic;

namespace AdventureWorks.BusinessLogic
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductSummary> GetProductSummaries()
        {
            return _productRepository.GetProductSummaries();
        }

        public byte[] GetProductPhoto(int productPhotoId)
        {
            return _productRepository.GetProductPhoto(productPhotoId);
        }

        public byte[] GetProductThumbnailPhoto(int productPhotoId)
        {
            return _productRepository.GetProductThumbnailPhoto(productPhotoId);
        }

        public ProductDetail GetProductDetail(int productId)
        {
            return _productRepository.GetProductDetail(productId);
        }
    }
}
