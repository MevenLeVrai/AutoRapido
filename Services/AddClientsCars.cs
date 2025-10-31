using AutoRapido.Model;

namespace AutoRapido.Services;

public interface IAddClientsCars
{
    Concession AddClientsAndCars(List<Client> clients, List<Car> cars);
}

public class AddClientsCars : IAddClientsCars
{
    private Concession Concession1 = new Concession();

    public Concession AddClientsAndCars(List<Client> clients, List<Car> cars)
    {
        foreach (var cl in clients)
        {
            Concession1.ListClients.Add(cl);
        }
        foreach (var c in cars)
        {
            Concession1.ListCars.Add(c);
        }

        return Concession1;
    }
}
