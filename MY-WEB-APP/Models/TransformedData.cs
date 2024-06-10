namespace MY_WEB_APP.Models
{
    public class TransformedData
    {
        public int Id { get; set; }
        public string ProcessedData { get; set; }
        public int RawDataId { get; set; }
        public RawData RawData { get; set; }
    }
}
