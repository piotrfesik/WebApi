using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Api.Configuration.AutoMapper;
using WebApplication.Data.Context;
using WebApplication.Data.Repositories.Configurations;
using WebApplication.Services.DtoModels;
using WebApplication.Services.Services.ConfigurationService;
using Xunit;

namespace WebApplication.Tests
{
    public class ConfigurationTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConfigurationTest()
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
            var rep = new ConfigurationItemRepository(_context);
            var service = new ConfigurationService(rep, _mapper);
            var testModel = new ConfigurationItemDtoModel
            {
                Id = 0,
                Name = "32 gb RAM",
                Cost = 50.39M,
                ConfigurationType = new ConfigurationTypeDtoModel
                {
                    Id = 1,
                    TypeName = "Ram"
                }
            };

            // Act
            await service.CreateConfigurationItem(testModel);
            var list = await service.GetAllConfigurationItems();

            // Assert
            Assert.Equal(7, list.Count);
            Assert.NotNull(list.FirstOrDefault(x => x.Name == testModel.Name));
            Assert.NotNull(list.FirstOrDefault(x => x.ConfigurationType.Id == testModel.ConfigurationType.Id));
        }
    }
}