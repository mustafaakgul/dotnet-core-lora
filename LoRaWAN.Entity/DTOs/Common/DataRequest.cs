namespace LoRaWAN.Entity.DTOs.Common
{
    public class DataRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public Sort Sort { get; set; }

        public DataRequest()
        {
            Offset = default;
            Limit = default;
            Sort = new Sort("ID");
        }

        public DataRequest(string orderBy)
        {
            Offset = default;
            Limit = default;
            Sort = new Sort(orderBy);
        }

        public DataRequest(int offset, int limit, Sort sort)
        {
            Offset = offset;
            Limit = limit;
            Sort = sort;
        }
    }

    public class DataRequest<T>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public Sort Sort { get; set; }
        public T Filters { get; set; }

        public DataRequest()
        {
            Offset = default;
            Limit = default;
            Sort = new Sort("ID");
            Filters = default;
        }

        public DataRequest(string orderBy)
        {
            Offset = default;
            Limit = default;
            Sort = new Sort(orderBy);
            Filters = default;
        }
    }
}
