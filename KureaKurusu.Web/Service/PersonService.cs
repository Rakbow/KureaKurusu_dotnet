using KureaKurusu.Data.DTO;
using KureaKurusu.Data.Models;
using KureaKurusu.Web.Access;

namespace KureaKurusu.Web.Service;

public class PersonService(IServiceProvider provider)
{
    private readonly ApplicationDbContext _dbContext = provider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    public async Task<Person> Detail(long id)
    {
        var person = await _dbContext.Persons.FindAsync(id);
        if (person == null) throw new Exception("Not Found");
        return person;
    }
}