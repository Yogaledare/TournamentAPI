using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Interfaces;
using TournamentAPI.Core.Mappers;
using TournamentAPI.Core.Services;
using TournamentAPI.Data.Data;
using TournamentAPI.Data.Repositories;
using TournamentAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TournamentApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddScoped<ITournamentApiMapper, TournamentApiMapper>();
builder.Services.AddScoped<IUoW, UoW>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>(); 
builder.Services.AddScoped<ITournamentService, TournamentService>(); 


// builder.Services.AddControllers().AddNewtonsoftJson(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapTournamentEndpoints();

app.Run();

