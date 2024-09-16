using ABPTask.Data;
using ABPTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ABPTask.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room> AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room> UpdateRoom(Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<bool> DeleteRoom(int roomId)
    {
        var room = await _context.Rooms.FindAsync(roomId);
        if (room == null) return false;

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Room>> GetAvailableRooms(DateTime dateTime, int capacity)
    {
        return await _context.Rooms
            .Where(r => r.Capacity >= capacity) 
            .ToListAsync();
    }

    public async Task<Booking> BookRoom(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }
}