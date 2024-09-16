using ABPTask.Models;

namespace ABPTask.Repositories;

public interface IRoomRepository
{
    Task<Room> AddRoom(Room room);
    Task<Room> UpdateRoom(Room room);
    Task<bool> DeleteRoom(int roomId);
    Task<IEnumerable<Room>> GetAvailableRooms(DateTime dateTime, int capacity);
    Task<Booking> BookRoom(Booking booking);
}