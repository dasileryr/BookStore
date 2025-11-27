namespace WinFormsApp3.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}

