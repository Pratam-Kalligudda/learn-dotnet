using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Difficulty> difficulties = new()
            {
                new()
                {
                    Id = Guid.Parse("28c8b650-dee4-44a1-a3a1-ddc90377faeb"),
                    Name = "Easy"
                },
                new()
                {
                    Id = Guid.Parse("e70d9a02-eed6-435f-a9c9-300f70d6656a"),
                    Name = "Medium"
                },
                new()
                {
                    Id = Guid.Parse("64662286-6321-45da-b36f-3def20384738"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            List<Region> regions = new()
            {
                new()
                {
                    Id = Guid.Parse("9a60fca5-8c43-41c5-95e2-c00b69908230"),
                    Code = "NSN",
                    Name ="Nelson",
                    RegionImageURL="https://images.pexels.com/photos/3396661/pexels-photo-3396661.jpeg"
                },
                new()
                {
                    Id = Guid.Parse("7b3eb59b-ff49-4a74-97fe-2e03705b21e7"),
                    Code = "AKL",
                    Name = "Auckland",
                    RegionImageURL="https://images.pexels.com/photos/33602901/pexels-photo-33602901.jpeg"
                },
                new()
                {
                    Id = Guid.Parse("2e042307-2f33-4642-9321-ed3fc637bb4e"),
                    Code = "BOP",
                    Name = "Bay of Plenty"
                },
                new()
                {
                    Id = Guid.Parse("e6e76066-9f9c-4514-8b18-21244bfaa6e6"),
                    Code = "NTL",
                    Name = "Northland"
                },
                new()
                {
                    Id = Guid.Parse("152f4b1a-4f66-4d49-b375-d736854e4138"),
                    Code = "STL",
                    Name = "SouthLand"
                },
                new()
                {
                    Id = Guid.Parse("511bc335-a23b-4cd2-bc3a-aefc03568811"),
                    Code = "WGN",
                    Name = "Wellington",
                    RegionImageURL="https://images.pexels.com/photos/3709402/pexels-photo-3709402.jpeg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
