using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Pizzeria.Core.Models;
using Pizzeria.Infrastructure.Data;

namespace IntegrationTest
{
    public static class Utilities
        {
            
            public static void InitializeDbForTests(ApplicationDbContext db)
            {
                db.FoodItems.AddRange();
                db.SaveChanges();
            }
    
            public static void ReinitializeDbForTests(ApplicationDbContext db)
            {
                db.FoodItems.RemoveRange(db.FoodItems);
                InitializeDbForTests(db);
            }
    
            public static List<FoodItem> GetSeedingMessages()
            {
                return new List<FoodItem>()
                {
                    new FoodItem(){Id = 1,Name = "hello",Price = 50},
                    new FoodItem(){Id = 2,Name = "hello1",Price = 150},
                    new FoodItem(){Id = 3,Name = "hello2",Price = 250}
                };
            }
            
        }
}

