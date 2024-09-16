using ABPTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ABPTask.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Models.Service> Services { get; set; }
}