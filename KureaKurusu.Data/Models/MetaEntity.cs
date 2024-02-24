using System.ComponentModel.DataAnnotations.Schema;

namespace KureaKurusu.Data.Models;

public class MetaEntity
{
    [Column("detail")]
    public string? Detail { get; set; }
    [Column("images")]
    public string? Images { get; set; }
    [Column("remark")]
    public string? Remark { get; set; }
    [Column("added_time")]
    public DateTime AddedTime { get; set; }
    [Column("edited_time")]
    public DateTime EditedTime { get; set; }
    [Column("status")]
    public int Status { get; set; }

    protected MetaEntity()
    {
        Detail = "";
        Images = "[]";
        Remark = "";
        AddedTime = DateTime.Now;
        EditedTime = DateTime.Now;
        Status = 1;
    }
}