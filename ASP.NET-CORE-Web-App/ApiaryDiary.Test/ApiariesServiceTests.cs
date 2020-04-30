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
    using ApiaryDiary.Data.Models;
    using System;
    using ApiaryDiary.Data.Models.Enums;

    public class ApiariesServiceTests
    {
        public ApiariesServiceTests()
        {
            
        }

        //[Theory]
        //[InlineData("")]
        //[InlineData("")]
        //[Fact]
        //public void ApiariesCountIsValid()
        //{
        //    var mockService = new Mock<IApiaryService>();
        //    mockService.Setup(x => x.ApiariesCount()).Returns(1);

        //    mockService.Verify(x => x.ApiariesCount(), Times.AtLeastOnce);
        //}

        [Fact]
        public async Task ApiariesCountIsValid()
        {
            var options = new DbContextOptionsBuilder<ApiaryDiaryDbContext>()
                .UseInMemoryDatabase("DbTest").Options;
            using var db = new ApiaryDiaryDbContext(options);

            var locationService = new LocationInfoService(db);
            var apiaryService = new ApiaryService(db, locationService);

            var userId = "dasadadadadas";
            var apiaryName = "Some appropriate name";
            var capacity = 100;

            var apiaryId = 
                await apiaryService.CreateAsync(userId, apiaryName, capacity);

            Assert.Equal(1, apiaryService.ApiariesCount());
        }

        [Fact] // Integration Test
        public async Task ApiaryDetailsContainsTotalCount()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var client = serverFactory.CreateClient();

            var response = await client.GetAsync("/Apiaries/ViewAll");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("__RequestVerificationToken", responseAsString);
        }
    }
}
