namespace Shoppers12.Models.Data
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
