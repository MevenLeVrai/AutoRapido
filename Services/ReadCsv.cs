using AutoRapido.Model;
using Npgsql;
using AutoRapido.Utils;
using AutoRapido.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace AutoRapido.Services;


public interface IServiceCSV
{
    Concessions ReadCSV(string path);
}

public class ServiceCSV :  IServiceCSV
{
    public Concessions ReadCSV(string path)
    {

        // code qui lit le CSV et met tout dans la classe

        List<Clients> persons = new List<Clients>();

        var ligne = File.ReadAllLinesClients(path);

        for (int i = 1; i < lignes.Length; i++)
        {
            String line = lignes[i];
            Clients person = new Clients();

            person.Lastname = line.Split(',')[1];
            person.Firstname = line.Split(',')[2];
            person.Birthdate = DateTimeUtils.ConvertToDateTime(line.Split(',')[3]);
            person.Size = Int32.Parse(line.Split(',')[5]);

            List<String> details = line.Split(',')[4].Split(';').ToList();

            person.AdressDetails = new List<Detail>
            {
                new (details[0], int.Parse(details[1]), details[2])
            };
            persons.Add(person);
        }

        Classe maClasse = new Classe();
        maClasse.Level = "B2";
        maClasse.Name = "B2 C#";
        maClasse.School = "SupDeVinci";
        maClasse.Persons = persons.ToList();
            
        return maClasse;
    }
}