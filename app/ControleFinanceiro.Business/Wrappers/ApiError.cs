namespace ControleFinanceiro.Business.Wrappers;

public class ApiError
{
    public string Title { get; set; }
    public string Message { get; set; }

    public ApiError(string title, string message)
    {
        Title = title;
        Message = message;
    }
}
