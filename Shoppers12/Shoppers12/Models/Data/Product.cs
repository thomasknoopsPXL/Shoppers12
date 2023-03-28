namespace Shoppers12.Models.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}
