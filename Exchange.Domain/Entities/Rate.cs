namespace Exchange.Domain.Entities
{
    public class Rate
    {
        public int? Segment { get; set; }
        public string Currency { get; set; }
        public long? Qty { get; set; }
        public string Value { get; set; }
    }
}
