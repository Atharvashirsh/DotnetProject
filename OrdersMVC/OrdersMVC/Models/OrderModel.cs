namespace OrdersMVC.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQty { get; set; }

    }
}
