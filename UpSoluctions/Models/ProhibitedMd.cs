namespace UpSoluctions.Models
{
    public class ProhibitedMd
    {
        public int Id { get; set; }
        public DateTime DtProhibited { get; set; }
        public BookMd BookId { get; set; }
        public float OrderPrice { get; set; }
    }
}
