namespace UpSoluctions.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual PublishingCompany PublishingCompany { get; set; }
        public virtual List<Prohibited> Prohibited { get; set; }
        public float SalePrice { get; set; }
    }
}
