using GraphQL.Types;
using HotelApi.Entities;

namespace HotelApi.Types
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Number);
            Field(x => x.AllowedSmoking);
            Field<RoomStatusType>(nameof(Room.Status));
        }
    }
}
