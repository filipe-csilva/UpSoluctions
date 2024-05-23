namespace UpSoluctions.Models
{
    public class BookMd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual CreateCategoryDto CategoryId { get; set; }
        public virtual AuthorMd AuthorId { get; set; }
        public virtual PublishingCompanyMd PublishingCompanyId { get; set; }
        public List<ProhibitedMd> ProhibitedId { get; set; }
        public float SalePrice { get; set; }
    }
}
