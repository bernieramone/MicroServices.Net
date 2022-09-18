using PlatformService.API.Models;

namespace PlatformService.API.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {

            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Platforms.AddRange(
                    new Platform 
                    {
                        Cost = "Free",
                        Id = 1,
                        Name = "Blazor Net",
                        Publisher = "Microsoft"
                    }, new Platform
                    {
                        Cost = "Free",
                        Id = 2,
                        Name = "Dot Net",
                        Publisher = "Microsoft"
                    }, new Platform
                    {
                        Cost = "Free",
                        Id = 3,
                        Name = "Python",
                        Publisher = "Python"
                    });
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> we already have data");
            }

        }
    }
}
