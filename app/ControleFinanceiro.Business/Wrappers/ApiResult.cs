using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.Wrappers;


public class ApiResult<T> : ApiResult
{
    public T Data { get; private set; }

    public ApiResult() { }
    public ApiResult(T data)
    {
        Data = data;
    }

    public ApiResult<T> SetData(T data)
    {
        Data = data;
        return this;
    }
}

public class ApiResult
{
    [JsonProperty]
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
    public bool HasError => Errors.Any();
    public ICollection<ApiError> Errors { get; private set; } = new List<ApiError>();

    public static ApiResult CreateInstance()
    {
        return new ApiResult();
    }

    public static ApiResult<TData> CreateInstance<TData>()
    {
        return new ApiResult<TData>();
    }

    public ApiResult AddServerError()
    {
        return AddServerError("Error", "An error has occurred. Please try again later");
    }

    public ApiResult AddServerError(string title, string message)
    {
        AddError(title, message);
        StatusCode = StatusCodes.Status500InternalServerError;

        return this;
    }

    public ApiResult AddRequestError(string title, string message)
    {
        AddError(title, message);
        StatusCode = StatusCodes.Status400BadRequest;

        return this;
    }

    public ApiResult AddError(string title, string message)
    {
        Errors.Add(new ApiError(title, message));
        return this;
    }

    public ApiResult AddError(string message)
    {
        AddError("Error", message);
        return this;
    }
}
