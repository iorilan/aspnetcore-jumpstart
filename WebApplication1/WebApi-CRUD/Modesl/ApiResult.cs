using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCRUD.Modesl
{
    public class ApiResult
    {
		private ApiResult() { }
	    public bool IsSuccess { get; set; }
	    public string ErrorMessage { get; set; }

	    public static ApiResult Ok()
	    {
			return new ApiResult(){IsSuccess = true};
	    }

	    public static ApiResult Error(string error)
	    {
			return new ApiResult(){ErrorMessage = error, IsSuccess = false};
	    }
	    public static ApiResult Error(Exception ex)
	    {
		    return new ApiResult() { ErrorMessage = ex.Message, IsSuccess = false };
	    }
	}


	public class ApiResult<T>
	{
		private ApiResult() { }
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public T Data { get; set; }

		public static ApiResult<T> Ok(T data)
		{
			return new ApiResult<T>() { IsSuccess = true , Data = data};
		}

		public static ApiResult<T> Error(string error)
		{
			return new ApiResult<T>() { ErrorMessage = error, IsSuccess = false };
		}
		public static ApiResult<T> Error(Exception ex)
		{
			return new ApiResult<T>() { ErrorMessage = ex.Message, IsSuccess = false };
		}
	}
}
