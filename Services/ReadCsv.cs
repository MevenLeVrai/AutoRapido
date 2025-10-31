using System.ComponentModel.DataAnnotations;
using AutoRapido.Model;
using Npgsql;
using AutoRapido.Utils;
using System.Globalization;

namespace AutoRapido.Services;


public interface IServiceCSV
{
    Concession ReadAllCSV(string pathClient, string pathCar);
    List<Client> ReadCSVClient(string path);
    List<Car> ReadCSVCar(string path);
}

public class ServiceCSV :  IServiceCSV
{
    public Concession ReadAllCSV(string pathClient, string pathCar)
    {
        var clients = ReadCSVClient(pathClient);
        var cars = ReadCSVCar(pathCar);

        // on crée une instance de la classe AddClientsCars
        AddClientsCars service = new AddClientsCars();

        // on appelle la méthode de cette instance
        Concession concession = service.AddClientsAndCars(clients, cars);

        return concession;
    }

    public List<Client> ReadCSVClient(string path)
    {

        // this code reads the csv file and update clients list.

        List<Client> clients = new List<Client>();

        var lines = File.ReadAllLines(path);

        for (int i = 1; i < lines.Length; i++)
        {
            String line = lines[i];
            Client client = new Client();
            
            client.LastName = line.Split('%')[0];
            client.FirstName = line.Split('%')[1];
            client.BirthDate = DateTimeUtils.ConvertToDateTime(line.Split('%')[2]);
            client.PhoneNumber = line.Split('%')[3]; //Change to Phone formatting later
            client.Email = line.Split('%')[4];
            clients.Add(client);
        }
        
        return clients;
    }
    
    public List<Car> ReadCSVCar(string path)
    {

        // this code reads the csv file and update cars list.

        List<Car> cars = new List<Car>();

        var lines = File.ReadAllLines(path);

        for (int i = 1; i < lines.Length; i++)
        {
            String line = lines[i];
            Car car = new Car();
            string[] lineSplit = line.Split('/');
            car.BrandName = lineSplit[0];
            car.ModelName = lineSplit[1];
            car.FirstRegistrationYear = DateTimeUtils.ConvertYearToDateTime(int.Parse(lineSplit[2]));
            car.Price = decimal.Parse(lineSplit[3], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            car.Color = lineSplit[4];
            car.IsSold= bool.Parse(lineSplit[5]);
            cars.Add(car);
        }
        
        return cars;
    }

    
}