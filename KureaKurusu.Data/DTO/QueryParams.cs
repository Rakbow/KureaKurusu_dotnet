namespace KureaKurusu.Data.DTO.Person;

public class QueryParams {

    public int page;
    public int size;
    public string? sortField;
    public int sortOrder;
    public Dictionary<string, Dictionary<string, object>> filters;

    private static String VALUE_KEY = "value";

    public QueryParams() {
        page = 0;
        size = 0;
        sortField = "";
        sortOrder = 0;
        filters = new Dictionary<string, Dictionary<string, object>>();
    }

    public bool asc() {
        return sortOrder == 1;
    }

    public QueryParams(ListQry qty) {
        size = qty.rows;
        page = qty.first/size + 1;
        sortField = qty.sortField;
        sortOrder = qty.sortOrder;
        filters = qty.filters;
    }

    public string? getStr(string key) {
        object value = filters[key][VALUE_KEY];
        return value.ToString();
    }

    public bool getBool(string key) {
        object value = filters[key][VALUE_KEY];
        return (bool) value;
    }

    public List<T> getArray<T>(string key) {
        object value = this.filters[key][VALUE_KEY];
        if(value == null) return null;
        return (List<T>) value;
    }

}