using AdventureWorks.DomainModels;
using System.Collections.Generic;

namespace AdventureWorks.BusinessLogic.Interfaces
{
    public interface IProductHandler
    {
        List<ProductSummary> GetProductSummaries();
        byte[] GetProductPhoto(int productPhotoId);
        byte[] GetProductThumbnailPhoto(int productPhotoId);
        ProductDetail GetProductDetail(int productId);
    }
}
