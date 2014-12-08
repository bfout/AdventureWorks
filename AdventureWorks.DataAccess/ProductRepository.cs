using AdventureWorks.DataAccess.Interfaces;
using AdventureWorks.DomainModels;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AdventureWorks.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductSummary> GetProductSummaries()
        {
            var productSummaries = new List<ProductSummary>();
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (var conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                using (var cmd = new SqlCommand("GetProductSummaries", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var productSummary = new ProductSummary();

                            productSummary.ListPrice = (decimal) rdr["ListPrice"];
                            productSummary.ProductDescription = rdr["ProductDescription"].ToString();
                            productSummary.ProductId = (int) rdr["ProductId"];
                            productSummary.ProductName = rdr["ProductName"].ToString();
                            productSummary.ProductPhotoId = (int)rdr["ProductPhotoId"];

                            productSummaries.Add(productSummary);
                        }
                    }
                }
                conn.Close();
            }

            return productSummaries;   
        }

        public byte[] GetProductPhoto(int productPhotoId)
        {
            Byte[] photo= null;
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GetProductPhoto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@productphotoid", productPhotoId));

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                            photo = (byte[])rdr["largephoto"];
                    }
                }
                conn.Close();
            }

            return photo;
        }

        public byte[] GetProductThumbnailPhoto(int productPhotoId)
        {
            Byte[] photo = null;
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GetProductThumbnailPhoto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@productphotoid", productPhotoId));

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                            photo = (byte[])rdr["thumbnailphoto"];
                    }
                }
                conn.Close();
            }

            return photo;
        }

        public ProductDetail GetProductDetail(int productId)
        {
            var productDetail = new ProductDetail();
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GetProductDetail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@productId", productId));

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            productDetail.ListPrice = (decimal)rdr["ListPrice"];
                            productDetail.ProductDescription = rdr["ProductDescription"].ToString();
                            productDetail.ProductId = (int)rdr["ProductId"];
                            productDetail.ProductName = rdr["ProductName"].ToString();
                            productDetail.ProductPhotoId = (int)rdr["ProductPhotoId"];
                        }
                    }
                }
                conn.Close();
            }

            return productDetail;
        }
    }
}
