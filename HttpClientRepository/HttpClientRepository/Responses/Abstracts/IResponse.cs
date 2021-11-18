using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientRepository.Responses.Abstracts
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
