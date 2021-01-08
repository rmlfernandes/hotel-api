using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelApi.Client
{
    public class Response<T>
    {
        public T Data { get; set; }

        public List<Error> Errors { get; set; }

        public void OnErrorThrowException()
        {
            if (this.Errors?.Any() == true)
            {
                throw new ApplicationException(
                    $"Message: {this.Errors[0].Message} Code: {this.Errors[0].Code}");
            }
        }
    }
}
