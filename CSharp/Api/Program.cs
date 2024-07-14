using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var inMemoryDatabase = new Dictionary<Guid, string>() {
	{Guid.Parse("cec32c91-dda0-44f0-9d86-8e8a1c36cf5e"), "order 1"},
	{Guid.Parse("15ec4f5b-fe3a-4668-93dd-9c5b88284679"), "order 2"},
	{Guid.Parse("b1bdcca0-7a80-461e-9a4b-a222557f4db4"), "order 3"},
	{Guid.Parse("ef2c716f-d2f6-44a3-8d75-06eb3b7ae711"), "order 4"},
	{Guid.Parse("7c01479c-c4f2-4720-a6d2-6716b0aff408"), "order 5"},
	{Guid.Parse("2e72fad9-13b9-4d39-9685-24c0bffe06b9"), "order 6"},
	{Guid.Parse("e4a28a1a-8b8d-4b76-aa03-05eac30f0c83"), "order 7"},
};

app.MapPost("/orders/", ([FromBody] string order) => Results.Problem("not implemented"))
	.WithName("CreateOrder")
	.WithOpenApi();

app.MapGet("/orders", () => Results.Ok(inMemoryDatabase))
	.WithName("GetAllOrders")
	.WithOpenApi();

app.MapGet("/orders/{id}", (Guid id) => Results.Problem("not implemented"))
	.WithName("GetOrderById")
	.WithOpenApi();

app.MapPut("/orders/{id}", (Guid id, [FromBody] string order) => Results.Problem("not implemented"))
	.WithName("UpdateOrderById")
	.WithOpenApi();

app.MapDelete("/orders/{id}", (Guid id) => Results.Problem("not implemented"))
	.WithName("DeleteOrderById")
	.WithOpenApi();

app.Run();

#if DEBUG
public partial class Program { }
#endif
