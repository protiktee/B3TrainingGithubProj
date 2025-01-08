using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace WebAppUpload.Models
{
    public class BaseProduct
    { 
        public int id { get; set; }
        public string title { get; set; }
        public string ProductDescription { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public double discountPercentage { get; set; }
        public string brand { get; set; }
        public string sku { get; set; }
        public double weight { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updateate { get; set; }
        public string barcode { get; set; }
        public string qrcode { get; set; }

        public List<string> Tags { get; set; }
        public List<BaseProductReview> reviews { get; set; }
        public List<BaseProductImage> images { get; set; }
        public BaseProduct()
        {
            Tags=new List<string>();
            reviews = new List<BaseProductReview>();
            images = new List<BaseProductImage>();
        }
        public void QryProduct(int ProductID)
        {
            DataTable dataTable = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "dbo.spEcom_QryProductByProductID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                //SqlDataReader reader = cmd.ExecuteReader();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                var Tags = (from q in dataTable.AsEnumerable() select q.Field<string>("Tag")).Distinct(); 
                foreach (string tag in Tags)
                { 
                    this.Tags.Add(tag);
                }
                var Reviews = (from q in dataTable.AsEnumerable() select new{
                    rating = q.Field<string>("rating"),
                    comment = q.Field<string>("comment"),
                    //date  =  q.Field<DateTime>("Tag"),
                    reviewername =   q.Field<string>("reviewername"),
                    reviewerEmail =q.Field<string>("reviewerEmail")
                }).ToList();
                foreach (var obj in Reviews)
                {
                    BaseProductReview baseProductReview = new BaseProductReview();
                    baseProductReview.rating = obj.rating;
                    baseProductReview.comment = obj.comment;
                    baseProductReview.reviewername = obj.reviewername;
                    baseProductReview.reviewerEmail = obj.reviewerEmail;
                    this.reviews.Add(baseProductReview);
                }

                var Images = (from q in dataTable.AsEnumerable()
                               select new
                               { 
                                   ImageType = q.Field<string>("ImageType"),
                                   ImageUrl = q.Field<string>("ImageUrl") 
                               }).ToList();
                foreach (var obj in Images)
                {
                    BaseProductImage baseProductImage = new BaseProductImage();
                    baseProductImage.ImageType = obj.ImageType;
                    baseProductImage.ImageUrl = obj.ImageUrl; 
                    this.images.Add(baseProductImage);
                }
                var ProductCommon = (from q in dataTable.AsEnumerable()
                              select new
                              {
                                  title = q.Field<string>("title"),
                                  ProductDescription = q.Field<string>("ProductDescription"),
                                  category = q.Field<string>("category"),
                                  //price = q.Field<double>("price"),
                                  //discountPercentage = q.Field<double>("discountPercentage"),
                                  brand = q.Field<string>("brand"),
                                  sku = q.Field<string>("sku"),

                                  //weight = q.Field<Int32>("weight"),
                                  //width = q.Field<Int32>("width"),
                                  //height = q.Field<Int32>("height"),
                                  //depth = q.Field<Int32>("depth"),

                                  //createdate = q.Field<Int32>("createdate"),
                                  //updateate = q.Field<Int32>("updateate"),

                                  barcode = q.Field<string>("barcode"),
                                  qrcode = q.Field<string>("qrcode")
                              }).ToList();
                foreach (var obj in ProductCommon)
                {
                    this.title = obj.title;
                    this.ProductDescription = obj.ProductDescription;
                    this.category = obj.category;
                    //price = q.Field<double>("price"),
                    //discountPercentage = q.Field<double>("discountPercentage"),
                    this.brand = obj.brand;
                    this.sku = obj.sku;

                    //weight = q.Field<Int32>("weight"),
                    //width = q.Field<Int32>("width"),
                    //height = q.Field<Int32>("height"),
                    //depth = q.Field<Int32>("depth"),

                    //createdate = q.Field<Int32>("createdate"),
                    //updateate = q.Field<Int32>("updateate"),

                    this.barcode = obj.barcode;
                    this.qrcode = obj.qrcode;
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            } 
        }
    }
}