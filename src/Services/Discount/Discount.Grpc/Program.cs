using Discount.Grpc.Data;
using Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddDbContext<DiscountContext>(opts => 
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database")));
var app = builder.Build();

app.UseMigration();
app.MapGrpcService<DiscountService>();

app.Run();
