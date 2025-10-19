namespace web_FE.Models // Đảm bảo namespace này khớp với tên project của bạn
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}