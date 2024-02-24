namespace KureaKurusu.Data.Common;

public class ApiResult {

    public int Code;//操作代码
    public int State;//操作状态 0-失败 1-成功
    public object? Data;//响应数据
    public long Total;//数据总数
    public string? Message;//错误信息

    private const int SuccessCode = 1;
    private const int FailCode = 0;

    public ApiResult() {
        State = SuccessCode;
        Message = "";
    }

    public ApiResult Ok(string message) {
        this.Message = message;
        return this;
    }

    public ApiResult Fail(Exception e) {
        State = FailCode;
        Message = e.Message;
        return this;
    }

    public ApiResult Fail(string error) {
        State = FailCode;
        Message = error;
        return this;
    }

    public void LoadData(object data) {
        this.Data = data;
    }
}