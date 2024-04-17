using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();

// COnfigure the Http pipeline
app.UseCors(builder => builder.AllowAnyHeader()
    .AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication(); // Asks do you have valid Token
app.UseAuthorization();

app.MapControllers();

app.Run();
