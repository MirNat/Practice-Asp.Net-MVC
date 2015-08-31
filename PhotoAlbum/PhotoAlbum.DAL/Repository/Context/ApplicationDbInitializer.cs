using PhotoAlbum.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace PhotoAlbum.DAL.Repository.Context
{
    class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //InitializeCategoriesForEF(context);
            base.Seed(context);
        }

        /*public static void InitializeCategoriesForEF(ApplicationDbContext db)
        {
            Category architectureCategory = new Category { Name = "Architecture"};
            Category natureCategory = new Category { Name = "Nature" };
            Category peopleCategory = new Category { Name = "People" };
            Category travellingCategory = new Category { Name = "Travelling" };
            Category professionCategory = new Category { Name = "Profession" };
            Category animalsCategory = new Category { Name = "Animals" };
            Category citiesCategory = new Category { Name = "Cities" };
            Category rareCadresCategory = new Category { Name = "Rare Cadres" };
            Category dailyLifeCategory = new Category { Name = "daily Life" };
            Category amazingViewCategory = new Category { Name = "Amazing View" };
            Category extremeCategory = new Category { Name = "Extreme" };
            Category funnyCategory = new Category { Name = "Funny" };
            db.Categories.Add(architectureCategory);
            db.Categories.Add(natureCategory);
            db.Categories.Add(peopleCategory);
            db.Categories.Add(travellingCategory);
            db.Categories.Add(professionCategory);
            db.Categories.Add(animalsCategory);
            db.Categories.Add(citiesCategory);
            db.Categories.Add(rareCadresCategory);
            db.Categories.Add(dailyLifeCategory);
            db.Categories.Add(amazingViewCategory);
            db.Categories.Add(extremeCategory);
            db.Categories.Add(funnyCategory);
        }*/
    }
}
