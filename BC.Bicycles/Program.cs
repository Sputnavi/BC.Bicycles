using BC.Bicycles.Helpers;
using BC.Bicycles.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllers().AddNewtonsoftJson();
services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
