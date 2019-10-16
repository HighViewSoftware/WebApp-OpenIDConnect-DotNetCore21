using System.ComponentModel.DataAnnotations.Schema;

namespace BopodaMVP.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class MVPUser
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string Name { get; internal set; }
    }

    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TenantUserRelationship
    {
        public int Id { get; set; }

        public int TenantId { get; set; }
        [ForeignKey(nameof(TenantId))]
        public Tenant Tenant { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public MVPUser User { get; set; }
    }
}
