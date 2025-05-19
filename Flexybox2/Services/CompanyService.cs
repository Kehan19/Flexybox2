using Flexybox2.Model;

namespace Flexybox2.Services;

public interface ICompanyService
{
    Task<Company> getCompanyById(int id);
    Task<List<Company>> getCompanies();
    
    // Favorites methods
    Task<List<int>> GetFavoriteIdsAsync();
    Task<bool> AddToFavoritesAsync(int companyId);
    Task<bool> RemoveFromFavoritesAsync(int companyId);
    Task<bool> IsFavoriteAsync(int companyId);
    Task<List<Company>> GetFavoriteCompaniesAsync();
    event Action<int> OnFavoriteAdded;
    event Action<int> OnFavoriteRemoved;
}

public class CompanyService : ICompanyService
{
    private readonly List<Company> _companies;
    private List<int> _favoriteIds = new List<int>();
    
    public event Action<int> OnFavoriteAdded;
    public event Action<int> OnFavoriteRemoved;

    public CompanyService()
    {
        
        _companies = new List<Company>
        {
            new Company { 
                Id = 1, 
                Name = "Aalborg",
                Address = "Østerågade 27",
                PostalCode = "9000",
                City = "Aalborg",
                Email = "aalborg@flexybox.com",
                Phone = "11 22 33 44",
                OpeningTimesRestaurant = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "07:00 - 22:00"},
                    {DayType.Friday, "07:00 - 22:00"},
                    {DayType.Saturday, "07:00 - 22:00"},
                    {DayType.Sunday, "07:00 - 22:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Takeaway hours
                OpeningTimesTakeaway = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:00 - 21:30"},
                    {DayType.Friday, "11:00 - 22:00"},
                    {DayType.Saturday, "11:00 - 22:00"},
                    {DayType.Sunday, "12:00 - 21:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Buffet hours
                OpeningTimesBuffet = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:30 - 14:30"},
                    {DayType.Friday, "11:30 - 14:30"},
                    {DayType.Saturday, "11:30 - 15:00"},
                    {DayType.Sunday, "11:30 - 15:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Special Events hours
                OpeningTimesSpecialEvents = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "By appointment"},
                    {DayType.Friday, "By appointment"},
                    {DayType.Saturday, "By appointment"},
                    {DayType.Sunday, "By appointment"},
                    {DayType.Holiday, "Closed"}
                }
            },
            new Company
            {
                Id = 2, 
                Name = "København",
                Address = "Østerågade 27",
                PostalCode = "1051",
                City = "København",
                Email = "KBH@flexybox.com",
                Phone = "44 22 11 33",
                OpeningTimesRestaurant = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "07:00 - 22:00"},
                    {DayType.Friday, "07:00 - 22:00"},
                    {DayType.Saturday, "07:00 - 22:00"},
                    {DayType.Sunday, "07:00 - 22:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Takeaway hours
                OpeningTimesTakeaway = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:00 - 21:30"},
                    {DayType.Friday, "11:00 - 22:00"},
                    {DayType.Saturday, "11:00 - 22:00"},
                    {DayType.Sunday, "12:00 - 21:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Buffet hours
                OpeningTimesBuffet = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:30 - 14:30"},
                    {DayType.Friday, "11:30 - 14:30"},
                    {DayType.Saturday, "11:30 - 15:00"},
                    {DayType.Sunday, "11:30 - 15:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Special Events hours
                OpeningTimesSpecialEvents = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "By appointment"},
                    {DayType.Friday, "By appointment"},
                    {DayType.Saturday, "By appointment"},
                    {DayType.Sunday, "By appointment"},
                    {DayType.Holiday, "Closed"}
                }
            },
            new Company
            {
                Id = 3, 
                Name = "Odense",
                Address = "Østerågade 27",
                PostalCode = "5000",
                City = "Odense",
                Email = "Odense@flexybox.com",
                Phone = "99 11 22 77",
                OpeningTimesRestaurant = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "07:00 - 22:00"},
                    {DayType.Friday, "07:00 - 22:00"},
                    {DayType.Saturday, "07:00 - 22:00"},
                    {DayType.Sunday, "07:00 - 22:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Takeaway hours
                OpeningTimesTakeaway = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:00 - 21:30"},
                    {DayType.Friday, "11:00 - 22:00"},
                    {DayType.Saturday, "11:00 - 22:00"},
                    {DayType.Sunday, "12:00 - 21:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Buffet hours
                OpeningTimesBuffet = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "11:30 - 14:30"},
                    {DayType.Friday, "11:30 - 14:30"},
                    {DayType.Saturday, "11:30 - 15:00"},
                    {DayType.Sunday, "11:30 - 15:00"},
                    {DayType.Holiday, "Closed"}
                },
                
                // Special Events hours
                OpeningTimesSpecialEvents = new Dictionary<DayType, string>
                {
                    {DayType.MondayToThursday, "By appointment"},
                    {DayType.Friday, "By appointment"},
                    {DayType.Saturday, "By appointment"},
                    {DayType.Sunday, "By appointment"},
                    {DayType.Holiday, "Closed"}
                }
            }
        };
    }

    public Task<Company> getCompanyById(int id)
    {
        return Task.FromResult(_companies.FirstOrDefault(c => c.Id == id));
    }

    public Task<List<Company>> getCompanies()
    {
        return Task.FromResult(_companies);
    }
    
    // Favorites Implementation
    public async Task<List<int>> GetFavoriteIdsAsync()
    {
        return await Task.FromResult(_favoriteIds.ToList());
    }

    public async Task<bool> AddToFavoritesAsync(int companyId)
    {
        if (!_favoriteIds.Contains(companyId))
        {
            _favoriteIds.Add(companyId);
            OnFavoriteAdded?.Invoke(companyId);
            return true;
        }
        return false;
    }

    public async Task<bool> RemoveFromFavoritesAsync(int companyId)
    {
        if (_favoriteIds.Remove(companyId))
        {
            OnFavoriteRemoved?.Invoke(companyId);
            return true;
        }
        return false;
    }

    public async Task<bool> IsFavoriteAsync(int companyId)
    {
        return await Task.FromResult(_favoriteIds.Contains(companyId));
    }

    public async Task<List<Company>> GetFavoriteCompaniesAsync()
    {
        var favoriteCompanies = new List<Company>();
        
        foreach (var id in _favoriteIds)
        {
            var company = await getCompanyById(id);
            if (company != null)
            {
                favoriteCompanies.Add(company);
            }
        }
        
        return favoriteCompanies;
    }
}