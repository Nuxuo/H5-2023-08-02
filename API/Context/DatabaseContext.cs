using H5_CASE_2023_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace H5_CASE_2023_API.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Building> Building { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Keycard> Keycard { get; set; }
        public DbSet<AccessLevel> AccessLevel { get; set; }
        public DbSet<ServerRoom> ServerRoom { get; set; }
        public DbSet<ServerRoomConditions> ServerRoomConditions { get; set; }
        public DbSet<ServerRoomEntryActivity> ServerRoomEntryActivity { get; set; }
        public DbSet<ServerRoomEntryAlarms> ServerRoomEntryAlarms { get; set; }
    }
}
