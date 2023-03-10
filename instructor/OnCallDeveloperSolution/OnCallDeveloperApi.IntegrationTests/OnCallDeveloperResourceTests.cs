
using Alba;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnCallDeveloperApi.Controllers;
using OnCallDeveloperApi.Models;

namespace OnCallDeveloperApi.IntegrationTests;

public class OnCallDeveloperResourceTests
{
    [Fact]
    public async Task CanGetOnCallDeveloperDuringBusinessHours()
    {
        // "Host" for our API our API will be up and running.
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
            stubbedBusinessClock.Setup(clock => clock.IsDuringBusinessHours()).Returns(true);

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IProvideTheBusinessClock>(stubbedBusinessClock.Object);
            });
        }); 

        // Scenarios  - 
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();

        });

        var expectedResponse = 
            new GetOnCallDeveloperResponse("Michael N.", "555-1212", "mike@aol.com");

        var actualResponse =  response.ReadAsJson<GetOnCallDeveloperResponse>();

        Assert.NotNull(actualResponse);

        Assert.Equal(expectedResponse, actualResponse);
        //Assert.Equal("Michael N.", actualResponse.Name);

        
    }
    [Fact]
    public async Task CanGetOnCallDeveloperOutsideBusinessHours()
    {
        // "Host" for our API our API will be up and running.
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedBusinessClock = new Mock<IProvideTheBusinessClock>();
            stubbedBusinessClock.Setup(clock => clock.IsDuringBusinessHours()).Returns(false);

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IProvideTheBusinessClock>(stubbedBusinessClock.Object);
            });
        });


        // Scenarios  - 
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();

        });

        var expectedResponse =
            new GetOnCallDeveloperResponse("OnCallCorp Customer Service", "800 GOOD-LUCK", "oncall@company.com");

        var actualResponse = response.ReadAsJson<GetOnCallDeveloperResponse>();

        Assert.NotNull(actualResponse);

        Assert.Equal(expectedResponse, actualResponse);

    }
}
