namespace UpSoluctions.Web.Identity.Models
{
    public class UserInfos
    {
        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
