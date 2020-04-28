namespace ApiaryDiary.Test
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Services;
    using ApiaryDiary.Services.Implementations;

    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Testing;

    public class ApiariesServiceTests
    {
        public ApiariesServiceTests()
        {
        }

        [Fact]
        //[Theory]
        //[InlineData("")]
        //[InlineData("")]
        public void ApiariesCountIsValid()
        {
            var mockService = new Mock<IApiaryService>();
            // mockService.Setup(x => x.CreateAsync(...)).Returns(...);

            // mockService.Verify(x => x.CreateAsync(), Times.AtLeastOnce);
        }

        [Fact]
        public void InMemoryDbTest()
        {
            var options = new DbContextOptionsBuilder<ApiaryDiaryDbContext>()
                .UseInMemoryDatabase("DbTest").Options;

            using var db = new ApiaryDiaryDbContext(options);
            var locationService = new LocationInfoService(db);
            var apiaryService = new ApiaryService(db, locationService);


        }

        [Fact] // Integration Test
        public async Task ApiaryDetailsContainsTotalCount()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var client = serverFactory.CreateClient();

            var response = await client.GetAsync("/Apiaries/ViewAll");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("TotalBeehives", responseAsString);
        }
    }
}
