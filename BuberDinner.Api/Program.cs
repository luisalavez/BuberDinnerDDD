
using BuberDinner.Api;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}