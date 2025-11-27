namespace WinFormsApp3.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }
        public string? CustomerName { get; set; }
    }
}

