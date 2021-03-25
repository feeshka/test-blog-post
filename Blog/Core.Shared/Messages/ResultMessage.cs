using System;

namespace Blog.Core.Shared
{
	public class ResultMessage<TEntityDto>
	{
		public ResultMessage (bool sucsess, int statusCode, string message, TEntityDto resultEntity)
		{
			Success = sucsess;
			StatusCode = statusCode;
			Message = message;
			Result = resultEntity;
		}
		public bool Success { get; }
		public int StatusCode { get; }
		public string Message { get; }
		public TEntityDto Result { get; }
	}
}
