using I3EfDatabase.Data;
using I3EfDatabase.Data.Tables;

namespace I3EfDatabase.Services;

public class DatabaseService
{
    private readonly ApplicationDbContext _db;

    public DatabaseService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Supporter Create(Supporter supporter)
    {
        supporter.SupporterId = Guid.NewGuid();
        supporter.Created = DateTimeOffset.Now; 
        
        _db.Supporters.Add(supporter);
        _db.SaveChanges();
        return supporter;
    }

    public int Count()
    {
        return _db.Supporters.Count();
    }
}