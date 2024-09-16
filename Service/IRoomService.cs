using ABPTask.Models;

namespace ABPTask.Service;

public interface IRoomService
{
    Task<Room> AddRoom(Room room);
    Task<Room> UpdateRoom(Room room);
    Task<bool> DeleteRoom(int roomId);
    Task<IEnumerable<Room>> GetAvailableRooms(DateTime dateTime, int capacity);
    Task<Booking> BookRoom(Booking booking);
    decimal CalculateTotalCost(Room room, DateTime bookingTime, int durationHours, List<Models.Service> selectedServices);
}