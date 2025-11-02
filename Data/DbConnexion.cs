using Npgsql;
using AutoRapido.Model;

namespace AutoRapido.Data;

public class DbConnexion
{
    private readonly ConcessionDbContext _appDbContext;
    public DbConnexion(ConcessionDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void SaveFullClasse(Concession myConcession) // Unused method to be implemented
    {
        _appDbContext.Add(myConcession);
        _appDbContext.SaveChanges();
    }
}