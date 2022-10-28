using System;

namespace metaproapp.Models.Response
{
    public class ServiceResponse
    {
        public bool status { get; set; }
        public object? data { get; set; }
        public string? message {get; set;}
    }
}
