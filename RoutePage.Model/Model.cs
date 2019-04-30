using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoutePage.Model
{
    public class RouteContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RoutePage.db");
        }
    }

    public class Route
    {

        public string RouteId { get; set; }
        // public string RouteName { get; set; }

        public List<Coordinate> Coordinates { get; set; }
    }

    public class Coordinate
    {
        public int CoordinateId { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public float Latitude { get; set; }



        public string RouteId { get; set; }
        public Route Route { get; set; }
    }
}
