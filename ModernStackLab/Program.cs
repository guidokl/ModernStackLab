using Microsoft.EntityFrameworkCore;
using ModernStackLab.Data;
using ModernStackLab.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// SWAGGER CONFIG
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DATABASE CONFIG
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTER SERVICE
builder.Services.AddScoped<IContactService, ContactService>();

// ALLOW FRONTEND - Step 1
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // The URL of your React App
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // --- 2. ENABLE THE UI PAGE ---
    app.UseSwagger();
    app.UseSwaggerUI(); // This creates the page at /swagger/index.html
    // -----------------------------
}

// ALLOW FRONTEND - Step 2
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();