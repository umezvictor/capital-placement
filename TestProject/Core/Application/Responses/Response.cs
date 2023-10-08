﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Responses
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(T data)
        {
            Succeeded = true;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public Response(T data, string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
        public T? Data { get; set; }
    }
}
