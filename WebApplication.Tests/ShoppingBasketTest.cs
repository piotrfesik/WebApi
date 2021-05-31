using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Api.Configuration.AutoMapper;
using WebApplication.Data.Context;
using WebApplication.Data.Repositories.Laptops;
using WebApplication.Services.Services.ShoppingBasket;
using Xunit;

namespace WebApplication.Tests
{
    public class ShoppingBasketTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingBasketTest()
        {
            var services = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(
                    options => options
                        .UseInMemoryDatabase("TestDB")
                        .UseInternalServiceProvider(
                            new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase()
                                .BuildServiceProvider()))
                .BuildServiceProvider();
            _context = services.GetRequiredService<ApplicationDbContext>();
            _context.Database.EnsureCreated();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile)));
            IMapper mapper = new Mapper(configuration);
            _mapper = mapper;
        }

        [Fact]
        public async Task Create_GetAll_Clear()
        {
            // Arrange
            var rep = new BasketRepository(_context);
            var lap = new LaptopRepository(_context);
            var service = new ShoppingBasketService(_mapper, rep,lap);

            // Act
            await service.AddLaptop(1);
            await service.AddLaptop(2);
            var list = await service.GetLaptopList();

            // Assert
            Assert.Equal(2, list.Count);
            
            // Act
            await service.RemoveLaptopList();
            var nextList = await service.GetLaptopList();

            // Assert
            Assert.Empty(nextList);
        }
    }
}