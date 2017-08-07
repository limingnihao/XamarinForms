using System;
namespace Community.Models
{
    public class ResultBean<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

}
