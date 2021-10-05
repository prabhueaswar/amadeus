namespace EmpApiService.Models.Response
{
    public class APIResponse
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public object ApiResult { get; set; }
    }
}
