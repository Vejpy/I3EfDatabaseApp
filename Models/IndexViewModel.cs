using I3EfDatabase.Data.Tables;

namespace I3EfDatabase.Models;

public class IndexViewModel
{
    public int SupportersCount { get; set; } = 0;
    public Supporter NewSupporter { get; set; } = new Supporter();
    public IndexViewModel() { }
    
    public IndexViewModel(int supportersCount)
    {
        SupportersCount = supportersCount;
    }
}