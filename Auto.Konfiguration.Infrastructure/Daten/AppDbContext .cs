using Auto.Konfiguration.Domain.Entities;
using Auto.Konfiguration.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Auto.Konfiguration.Infrastructure.Daten
{
    public class AppDbContext : DbContext, IAppDbContextService
    {
        public DbSet<Engine> Engines => Set<Engine>();
        public DbSet<Paint> Paints => Set<Paint>();
        public DbSet<Rims> Rimses => Set<Rims>(); 
        public DbSet<OptionalEquipment> OptionalEquipments => Set<OptionalEquipment>(); 

        public DbSet<CarConfiguration> Configurations => Set<CarConfiguration>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=carconfig.db");

        public void InsertDB()
        {
            Database.EnsureCreated();

            if (!Engines.Any())
            {
                Engines.AddRange(
                    new Engine { Power = 100, Price = 1000 },
                    new Engine { Power = 150, Price = 2000 },
                    new Engine { Power = 200, Price = 2500 },
                    new Engine { Power = 250, Price = 3000 },
                    new Engine { Power = 300, Price = 3500 }
                );
            }

            if (!Paints.Any())
            {
                Paints.AddRange(
                    new Paint { Name = "Weiß", Price = 100 },
                    new Paint { Name = "Rot", Price = 150 },
                    new Paint { Name = "Blau", Price = 200 },
                    new Paint { Name = "Silber", Price = 220 },
                    new Paint { Name = "Schwarz Metallic", Price = 250 }
                );
            }

            if(!Rimses.Any())
            {
                Rimses.AddRange(
                    new Rims { Name = "Stahlfelgen", Price = 500 },
                    new Rims { Name = "Alufelgen", Price = 1000 },
                    new Rims { Name = "Schmiedefelgen", Price = 1500 },
                    new Rims { Name = "Mehrteilige Felgen", Price = 2000 }
                );
            }

            if(!OptionalEquipments.Any())
            {
                OptionalEquipments.AddRange(
                    new OptionalEquipment { Name = "Klimaanlage", Price = 1000 },
                    new OptionalEquipment { Name = "Soundsystem", Price = 600 },
                    new OptionalEquipment { Name = "Sitzheizung", Price = 400 },
                    new OptionalEquipment { Name = "Automatik", Price = 200 },
                    new OptionalEquipment { Name = "Sportsitze", Price = 400 },
                    new OptionalEquipment { Name = "Einparkhilfe", Price = 100 },
                    new OptionalEquipment { Name = "Anhägerkupplung", Price = 80 },
                    new OptionalEquipment { Name = "GPS-Tracker", Price = 50 }
                );
            }

            SaveChanges();
        }

        public List<Engine> GetEngines()
        {
            return Engines.ToList();
        }

        public List<Paint> GetPaints()
        {
            return Paints.ToList();
        }

        public List<Rims> GetRims()
        {
            return Rimses.ToList();
        }

        public List<OptionalEquipment> GetOptionalEquipment()
        {
            return OptionalEquipments.ToList();
        }
    }
}
