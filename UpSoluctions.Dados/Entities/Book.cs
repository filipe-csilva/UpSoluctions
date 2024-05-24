namespace UpSoluctions.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Category CategoryId { get; set; }
        public virtual Author AuthorId { get; set; }
        public virtual PublishingCompany PublishingCompanyId { get; set; }
        public List<Prohibited> ProhibitedId { get; set; }
        public float SalePrice { get; set; }
    }
}
