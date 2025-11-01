using AutoRapido.Model;

namespace AutoRapido.Services;

public interface IAddClientsCars
{
    Concession AddClientsAndCars(List<Client> clients, List<Car> cars);
}

public class AddClientsCars : IAddClientsCars
{
    private readonly Concession _concession = new Concession();

    public Concession AddClientsAndCars(List<Client> clients, List<Car> cars)
    {
        foreach (var cl in clients)
        {
            _concession.ListClients.Add(cl);
        }
        foreach (var c in cars)
        {
            _concession.ListCars.Add(c);
        }

        return _concession;
    }
}
