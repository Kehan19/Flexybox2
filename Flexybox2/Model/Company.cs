namespace Flexybox2.Model;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    
    public Dictionary<DayType, string> OpeningTimesRestaurant { get; set; } = new();
    public Dictionary<DayType, string> OpeningTimesTakeaway { get; set; } = new();
    public Dictionary<DayType, string> OpeningTimesBuffet { get; set; } = new();
    public Dictionary<DayType, string> OpeningTimesSpecialEvents { get; set; } = new();

    public string PostalCode { get; set; }
    public string City { get; set; }
}
public enum DayType
{
    MondayToThursday,
    Friday,
    Saturday,
    Sunday,
    Holiday
}