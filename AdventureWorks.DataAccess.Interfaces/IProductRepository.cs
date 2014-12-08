using AdventureWorks.DomainModels;
using System.Collections.Generic;

namespace AdventureWorks.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        List<ProductSummary> GetProductSummaries();
        byte[] GetProductPhoto(int productPhotoId);
        byte[] GetProductThumbnailPhoto(int productPhotoId);
        ProductDetail GetProductDetail(int productId);
    }
}
