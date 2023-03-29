using FluentValidation;
using FluentValidation.AspNetCore;
using Library.BusinessLayer.Services;
using Library.BusinessLayer.Services.Interfaces;
using Library.DataAccess;
using Library.DataAccess.Repositories;
using Library.DataAccess.Repositories.Interfaces;
using Library.Presentation.Profiles;
using Library.Presentation.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddDbContext<LibraryContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddValidatorsFromAssemblyContaining<GenreValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(ApplicationProfiles));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IEditionHouseRepository, EditionHouseRepository>();
builder.Services.AddScoped<IEditionHouseService, EditionHouseService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
