namespace WinFormsApp3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string AuthorFullName { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int? ContinuationOfBookId { get; set; }
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public decimal? SaleDiscount { get; set; }
    }
}

