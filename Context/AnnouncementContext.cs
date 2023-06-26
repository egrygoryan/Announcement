using Microsoft.EntityFrameworkCore;

namespace AnnouncementApi.Context;

public class AnnouncementContext : DbContext
{
    public AnnouncementContext(DbContextOptions<AnnouncementContext> options) : base(options) { }
    public DbSet<AnnouncementModel> Announcements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}