namespace ABPTask.Models;

public class Booking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public DateTime BookingTime { get; set; }
    public int DurationHours { get; set; }
    public List<Service> SelectedServices { get; set; } = new();
    public decimal TotalCost { get; set; }
}