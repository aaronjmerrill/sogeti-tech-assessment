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
	{Guid.NewGuid(), "order 1"},
	{Guid.NewGuid(), "order 2"},
	{Guid.NewGuid(), "order 3"},
	{Guid.NewGuid(), "order 4"},
	{Guid.NewGuid(), "order 5"},
	{Guid.NewGuid(), "order 6"},
	{Guid.NewGuid(), "order 7"},
};

app.MapPost("/order/", ([FromBody] string order) => Results.Problem("not implemented"))
.WithName("CreateOrder")
.WithOpenApi();

app.MapGet("/order", () => Results.Ok(inMemoryDatabase))
.WithName("GetAllOrders")
.WithOpenApi();

app.MapGet("/order/{id}", (Guid id) => Results.Problem("not implemented"))
.WithName("GetOrderById")
.WithOpenApi();

app.MapPut("/order/{id}", (Guid id, [FromBody] string order) => Results.Problem("not implemented"))
.WithName("UpdateOrderById")
.WithOpenApi();

app.MapDelete("/order/{id}", (Guid id) => Results.Problem("not implemented"))
.WithName("DeleteOrderById")
.WithOpenApi();

app.Run();
