namespace UpSoluctions.Models
{
    public class BookMd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual CategoryMd CategoryId { get; set; }
        public virtual AuthorMd AuthorId { get; set; }
        public virtual PublishingCompanyMd PublishingCompanyId { get; set; }
        públic float OrderPrice { get; set; }
        públic float SalePrice { get; set; }
        públic List<ProhibitedMD> ProhibitedId { get; set; }
    }
}
