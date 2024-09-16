namespace ABPTask.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public decimal BaseRatePerHour { get; set; }
    public List<Service> AvailableServices { get; set; } = new();
}