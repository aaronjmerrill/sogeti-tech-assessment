using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Test;

public class ApiWebApplicationFactory : WebApplicationFactory<Program> {
	protected override void ConfigureWebHost(IWebHostBuilder builder) {
		builder.ConfigureAppConfiguration(config => { });
		builder.ConfigureTestServices(services => { });
	}
}

public class OrdersControllerTests : IClassFixture<ApiWebApplicationFactory> {
	private readonly HttpClient _client;
	public OrdersControllerTests(ApiWebApplicationFactory fixture) {
		_client = fixture.CreateClient();
	}

	[Fact]
	public async Task GetAll_ShouldReturn7Records() {
		var response = await _client.GetAsync("/orders");
		var actual = await response.Content.ReadFromJsonAsync<Dictionary<Guid, string>>();

		Assert.Equal(7, actual?.Count);
	}

	[Fact]
	public async Task GetAll_ShouldReturnCorrectOrders() {
		var response = await _client.GetAsync("/orders");
		var actual = await response.Content.ReadFromJsonAsync<Dictionary<Guid, string>>();

		if (actual is null) Assert.Fail("Response should not be null");

		string[] expectedOrders = [
			"order 1",
			"order 2",
			"order 3",
			"order 4",
			"order 5",
			"order 6",
			"order 7",
		];

		foreach (var expected in expectedOrders) {
			Assert.Contains(actual, item => item.Value == expected);
		}
	}
}
