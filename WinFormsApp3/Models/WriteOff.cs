namespace WinFormsApp3.Models
{
    public class WriteOff
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime WriteOffDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}

