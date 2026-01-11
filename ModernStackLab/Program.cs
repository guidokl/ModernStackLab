using Microsoft.EntityFrameworkCore;
using ModernStackLab.Data;
using ModernStackLab.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// 1. SWAGGER CONFIG
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. DATABASE CONFIG
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. REGISTER SERVICE
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // --- 2. ENABLE THE UI PAGE ---
    app.UseSwagger();
    app.UseSwaggerUI(); // This creates the page at /swagger/index.html
    // -----------------------------
}

app.UseAuthorization();

app.MapControllers();

app.Run();