using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientRepository.Responses.Abstracts
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
    }
}
