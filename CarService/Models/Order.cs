namespace CarServiceApi.Models
{
    public class Order
    {
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
    }
}