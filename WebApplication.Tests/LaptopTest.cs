using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Api.Configuration.AutoMapper;
using WebApplication.Data.Context;
using WebApplication.Data.Repositories.Laptops;
using WebApplication.Services.DtoModels;
using WebApplication.Services.Services.LaptopService;
using Xunit;

namespace WebApplication.Tests
{
    public class LaptopTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LaptopTest()
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
        public async Task Create_And_GetAll()
        {
            // Arrange
            var rep = new LaptopRepository(_context);
            var service = new LaptopService(rep, _mapper);
            var testModel = new LaptopsDtoModel()
            {
                Id = 0,
                Name = "New PC",
                BrandId = 3,
                LaptopConfiguration = new List<LaptopConfigurationDtoView>
                {
                    new()
                    {
                        ConfigurationItemId = 1
                    },
                    new()
                    {
                        ConfigurationItemId = 3
                    },
                    new()
                    {
                        ConfigurationItemId = 5
                    }
                }
            };

            // Act
            await service.CreateLaptop(testModel);
            var list = await service.GetAllLaptops();

            // Assert
            Assert.Equal(3, list.Count);
            Assert.NotNull(list.FirstOrDefault(x => x.Name == testModel.Name
                                                    && x.BrandId == testModel.BrandId && x.LaptopConfiguration.Count == 3));
        }
    }
}