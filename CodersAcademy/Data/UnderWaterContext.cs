using CodersAcademy.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Models;

namespace CodersAcademy.Data
{
    public class UnderWaterContext : DbContext
    {

        public DbSet<Fish> Fishes { get; set; }
        public DbSet<Aquarium> Aquariums { get; set; }

        public UnderWaterContext(DbContextOptions<UnderWaterContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FishMap());
            modelBuilder.ApplyConfiguration(new AquariumMap());
        }
    }
}
