using ABPTask.Models;
using ABPTask.Repositories;

namespace ABPTask.Service;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Room> AddRoom(Room room) => await _roomRepository.AddRoom(room);

    public async Task<Room> UpdateRoom(Room room) => await _roomRepository.UpdateRoom(room);

    public async Task<bool> DeleteRoom(int roomId) => await _roomRepository.DeleteRoom(roomId);

    public async Task<IEnumerable<Room>> GetAvailableRooms(DateTime dateTime, int capacity) 
        => await _roomRepository.GetAvailableRooms(dateTime, capacity);

    public async Task<Booking> BookRoom(Booking booking) => await _roomRepository.BookRoom(booking);

    public decimal CalculateTotalCost(Room room, DateTime bookingTime, int durationHours,
        List<Models.Service> selectedServices)
    {
        decimal totalCost = room.BaseRatePerHour * durationHours;

        foreach (var service in selectedServices)
        {
            totalCost += service.Price;
        }
        
        if (bookingTime.Hour >= 18 && bookingTime.Hour <= 23)
        {
            totalCost *= 0.8m; // 20% знижка
        }
        else if (bookingTime.Hour >= 6 && bookingTime.Hour < 9)
        {
            totalCost *= 0.9m; // 10% знижка
        }
        else if (bookingTime.Hour >= 12 && bookingTime.Hour < 14)
        {
            totalCost *= 1.15m; // 15% націнка
        }

        return totalCost;
    }
}