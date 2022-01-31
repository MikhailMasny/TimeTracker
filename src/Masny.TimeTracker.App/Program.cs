using Masny.TimeTracker.Data.Contexts;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Managers;
using Masny.TimeTracker.Logic.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Masny.TimeTracker.App
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped(typeof(IRepositoryManager<>), typeof(RepositoryManager<>))
                .AddScoped<IUserManager, UserManager>()
                .AddDbContext<ApplicationContext>()
                .BuildServiceProvider();

            // code

            var userManager = serviceProvider.GetService<IUserManager>();

            var userTest = new UserDto
            {
                FullName = "Test",
                Email = "email@email.email",
                Password = "password"
            };

            await userManager.CreateAsync(userTest);
        }
    }
}
