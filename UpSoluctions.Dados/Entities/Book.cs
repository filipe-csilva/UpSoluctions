namespace UpSoluctions.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public Author Author { get; set; }
        public virtual PublishingCompany PublishingCompany { get; set; }
        public List<Prohibited> ProhibitedId { get; set; }
        public float SalePrice { get; set; }
    }
}
