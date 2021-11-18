﻿using HttpClientRepository.Responses.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientRepository.Responses.Concrete
{
    public class Response : IResponse
    {
        public Response(bool success)
        {
            Success = success;
        }
        public Response(bool success, string message) : this(success) //this = bu class , burada iki parametreli constructor çalışrığında tek parametreli constructor'da çalışacak.
        {
            Message = message;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}