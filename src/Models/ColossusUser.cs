namespace BopodaMVP.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class MVPUser
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string Name { get; internal set; }
    }
}
