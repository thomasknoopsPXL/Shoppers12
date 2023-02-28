namespace Shoppers12.Models.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? PromisedDeliveryDate { get; set; }
    }
}
