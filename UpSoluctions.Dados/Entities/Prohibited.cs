namespace UpSoluctions.Data.Entities
{
    public class Prohibited
    {
        public int Id { get; set; }
        public DateTime DtProhibited { get; set; }
        public Book BookId { get; set; }
        public float OrderPrice { get; set; }
    }
}
