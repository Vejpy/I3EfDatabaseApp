namespace I3EfDatabase.Data.Tables;

public class Supporter
{
    public Guid SupporterId { get; set; }   
    public DateTimeOffset Created  { get; set; }
    
    public string Name { get; set; }    
    public string Surname { get; set; }
    public string Email { get; set; }
    
    public string? Occupation { get; set; }
    public string? PhoneNumber { get; set; }
    
}