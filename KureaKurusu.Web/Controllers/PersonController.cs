using KureaKurusu.Data.Common;
using KureaKurusu.Data.DTO;
using KureaKurusu.Data.DTO.Person;
using KureaKurusu.Data.Models;
using KureaKurusu.Web.Access;
using KureaKurusu.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace KureaKurusu.Web.Controllers;

[Route("db/[controller]")]
[ApiController]
public class PersonController(ApplicationDbContext dbContext, PersonService service) : ControllerBase
{
    // 构造函数中注入DbContext

    [HttpPost("add")]
    public async Task<ApiResult> AddPerson(Person person)
    {
        var res = new ApiResult();
        try
        {
            dbContext.Persons.Add(person);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            res.Fail(e);
        }
        return res;
    }

    [HttpPost("detail")]
    public async Task<ApiResult> GetPersonDetail(DetailQry qry)
    {
        var res = new ApiResult();
        try
        {
            res.LoadData(await service.Detail(qry.Id));
        }
        catch (Exception e)
        {
            res.Fail(e);
        }
        return res;
    }

    [HttpPost("list")]
    public async Task<ApiResult> GetPersons(ListQry qry)
    {
        var res = new ApiResult();
        try
        {
            QueryParams param = new(qry);
            string? name = param.getStr("name");
            string? nameZh = param.getStr("nameZh");
            string? nameEn = param.getStr("nameEn");
            string? aliases = param.getStr("aliases");

            List<Person> persons = dbContext.Persons
                .Where(i => 
                    i.Name!.Contains(name ?? "")
                    && i.NameZh!.Contains(nameZh ?? "")
                    && i.NameEn!.Contains(nameEn ?? "")
                    && i.Aliases!.Contains(aliases ?? "")
                    && param.getArray<int>("gender").Contains(i.Gender)
                    )
                .Skip((param.page - 1) * param.size)
                .Take(param.size)
                .ToList();
        }
        catch (Exception e)
        {
            res.Fail(e);
        }
        return res;
    }
}