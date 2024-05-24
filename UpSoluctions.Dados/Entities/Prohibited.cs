namespace UpSoluctions.Data.Entities
{
    public class Prohibited
    {
        public int Id { get; set; }
        public DateTime DtProhibited { get; set; }
        public Book Book { get; set; }
        public float OrderPrice { get; set; }
    }
}
