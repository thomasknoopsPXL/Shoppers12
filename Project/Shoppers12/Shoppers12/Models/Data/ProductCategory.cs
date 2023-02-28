namespace Shoppers12.Models.Data
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string? ProductCategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
