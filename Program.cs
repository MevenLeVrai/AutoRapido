using AutoRapido;
using AutoRapido.Data;
using AutoRapido.Model;
using AutoRapido.Utils;
using AutoRapido.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(GlobalVariable.JsonPath, optional: false, reloadOnChange: true)
    .Build();


#region Connexion

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Enregistrer le DbContext EF
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

#endregion

var service = scope.ServiceProvider.GetRequiredService<IServiceCSV>(); // Création de l'instance
Concession concession = service.ReadAllCSV(
configuration.GetSection("CSVPath")["ClientCSV"], 
configuration.GetSection("CSVPath")["CarCSV"]);
concession.Name = "AutoRapido";

if (!dbContext.Concession.Any(c => c.Name == "AutoRapido"))
{
    dbContext.Concession.Add(concession);
    dbContext.SaveChanges();
}

#region State machine

stateMachine.Run();

#endregion
