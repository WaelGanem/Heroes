using HEROESAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS configuration here
builder.Services.AddCors();

// ... other code 

// Add services 
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); // For cross-origin requests
builder.Services.AddScoped<DataAccess>(); // Register DataAccess 

// Build the application
var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

// Add CORS middleware
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



app.UseAuthorization();

app.MapControllers();

app.Run();
