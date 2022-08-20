using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models;
using SICUENTANOS_Back.Repository;
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
); 

builder.Services.AddTransient<IGenericRepository>();


//Enable CORS
builder.Services.AddCors(opt=>{
    opt.AddPolicy(name: myAllowSpecificOrigins,
        builder=>{
            //builder.WithOrigins("http://localhost:4200")
            // Origen creando objeto tipo Uri en donde el origin será recibido y llamado localhost
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

using (var scope =app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
