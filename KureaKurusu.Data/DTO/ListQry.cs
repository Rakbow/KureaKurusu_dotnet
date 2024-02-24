namespace KureaKurusu.Data.DTO.Person;

public class ListQry
{
    public int first { get; set; }
    public int rows { get; set; }
    public string? sortField { get; set; }
    public int sortOrder { get; set; }
    public Dictionary<string, Dictionary<string, object>> filters { get; set; }
}