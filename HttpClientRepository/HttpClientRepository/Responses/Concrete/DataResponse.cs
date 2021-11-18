using HttpClientRepository.Responses.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientRepository.Responses.Concrete
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
