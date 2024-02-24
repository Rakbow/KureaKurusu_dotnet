using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KureaKurusu.Data.Models;

[Table("person")]
public class Person : MetaEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("name_zh")]
    public string? NameZh { get; set; }
    [Column("name_en")]
    public string? NameEn { get; set; }
    [Column("aliases")]
    public List<string>? Aliases { get; set; }
    [Column("cover")]
    public string? Cover { get; set; }
    [Column("gender")]
    public int Gender { get; set; }
    [Column("birth_date")]
    public string? BirthDate { get; set; }
    [Column("links")]
    public List<Link>? Links { get; set; }
    [Column("info")]
    public string? Info { get; set; }

    public Person()
    {
        Id = 0L;
        Name = "";
        NameZh = "";
        NameEn = "";
        Aliases = new();
        Cover = "[]";
        Gender = 0;
        BirthDate = "????/??/??";
        Links = new();
        Info = "{}";
    }
}