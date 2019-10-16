using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BopodaMVP.Models
{
    public class MVPUser
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string Name { get; internal set; }

        [InverseProperty(nameof(OrganizationUserRelationship.User))]
        public IEnumerable<OrganizationUserRelationship> Organizations { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(OrganizationUserRelationship.Organization))]
        public IEnumerable<OrganizationUserRelationship> Users { get; set; }
    }

    public class OrganizationUserRelationship
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public MVPUser User { get; set; }
    }
}
