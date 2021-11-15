using System.ComponentModel;

namespace LoRaWAN.Entity.DTOs.Common
{
    public class Sort
    {
        public string Order { get; set; }
        public ListSortDirection Direction { get; set; }

        public Sort()
        {
            Order = default;
            Direction = default;
        }

        public Sort(string orderBy)
        {
            Order = orderBy;
            Direction = default;
        }

        public Sort(string orderBy, int direction)
        {
            Order = orderBy;
            Direction = (ListSortDirection)direction;
        }

        public Sort(string orderBy, ListSortDirection direction)
        {
            Order = orderBy;
            Direction = direction;
        }
    }
}
