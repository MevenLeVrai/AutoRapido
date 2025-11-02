using AutoRapido;
using AutoRapido.Data;
using AutoRapido.Model;
using AutoRapido.Utils;
using AutoRapido.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(GlobalVariable.JsonPath, optional: false, reloadOnChange: true)
    .Build();


#region Connexion

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Registering DbContext EF
        services.AddDbContext<ConcessionDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddTransient<ActionsService>();
        services.AddTransient<MenuService>();
        services.AddTransient<StateMachine>();
        services.AddTransient<DbConnexion>();
        services.AddTransient<IServiceCSV, ServiceCSV>();
    })
    .Build();
#endregion

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ConcessionDbContext>();
var stateMachine =  scope.ServiceProvider.GetRequiredService<StateMachine>();
dbContext.Database.Migrate();

#region Lecture des CSV et relation concession 

var service = scope.ServiceProvider.GetRequiredService<IServiceCSV>(); //Instance creation.
Concession concession = service.ReadAllCsv(
configuration.GetSection("CSVPath")["ClientCSV"], 
configuration.GetSection("CSVPath")["CarCSV"]);
concession.Name = "AutoRapido";

if (!dbContext.Concession.Any(c => c.Name == "AutoRapido"))
{
    dbContext.Concession.Add(concession);
    dbContext.SaveChanges();
}
#endregion

#region Run State machine

stateMachine.Run();

#endregion
