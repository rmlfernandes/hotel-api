using System;
using GraphQL.Types;
using HotelApi.Queries;

namespace HotelApi.Schemas
{
    public class MyHotelSchema : Schema
    {
        public MyHotelSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = (MyHotelQuery)serviceProvider.GetService(typeof(MyHotelQuery));
        }
    }
}
