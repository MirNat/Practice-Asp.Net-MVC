namespace PhotoAlbum.DAL.Migrations
{
    using PhotoAlbum.Entities.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoAlbum.DAL.Repository.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoAlbum.DAL.Repository.Context.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Name = "Architecture" },
                new Category { Name = "Nature" },
                new Category { Name = "People" },
                new Category { Name = "Travelling" },
                new Category { Name = "Profession" },
                new Category { Name = "Animals" },
                new Category { Name = "Cities" },
                new Category { Name = "Rare Cadres" },
                new Category { Name = "Daily Life" },
                new Category { Name = "Amazing View" },
                new Category { Name = "Extreme" },
                new Category { Name = "Funny" }
                );
        }
    }
}
