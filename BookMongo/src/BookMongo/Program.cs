using BookMongo.App.Interfaces;
using BookMongo.Domain;
using BookMongo.Infastructure.Persistence.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase("BookMongo");

builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);
builder.Services.AddScoped(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<Book>("Books");
});
builder.Services.AddScoped<IMongoBook, MongoBook>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.Run();

