using System;
using System.Collections.Generic;
namespace DataModel.common
{
    public class ResponseModel<T>
    {
        public List<T> Data { get; set; }
        public ResponseModel<Employee> Success { get; set; }
        public ErrorModel Error { get; set; }
        public int TotalCount { get; set; }

        public static implicit operator ResponseModel<T>(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
