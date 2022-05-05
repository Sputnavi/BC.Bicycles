using BC.Bicycles.Helpers;
using BC.Bicycles.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.ConfigureSqlContext(configuration);
services.AddAutoMapper(typeof(Program));
services.RegisterRepositories();
services.AddControllers().AddNewtonsoftJson();
services.ConfigureCorsPolicy();
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
