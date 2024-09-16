using ABPTask.Models;
using ABPTask.Service;
using Microsoft.AspNetCore.Mvc;

namespace ABPTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRoom(Room room)
    {
        var createdRoom = await _roomService.AddRoom(room);
        return Ok(createdRoom);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateRoom(int id, Room room)
    {
        room.Id = id;
        var updatedRoom = await _roomService.UpdateRoom(room);
        return Ok(updatedRoom);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var isDeleted = await _roomService.DeleteRoom(id);
        if (!isDeleted) return NotFound();
        return Ok();
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime dateTime, [FromQuery] int capacity)
    {
        var rooms = await _roomService.GetAvailableRooms(dateTime, capacity);
        return Ok(rooms);
    }

    [HttpPost("book")]
    public async Task<IActionResult> BookRoom(Booking booking)
    {
        var bookedRoom = await _roomService.BookRoom(booking);
        return Ok(bookedRoom);
    }
}