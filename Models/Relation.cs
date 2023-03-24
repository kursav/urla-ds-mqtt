using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urla.DS.MQTT.Models
{
    public class Relation
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid RelatedAccountId { get; set; }
        public Guid? PermissionId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string Username { get; set; }
        public string? Information { get; set; }
        public string? MobileNumber { get; set; }
        public string? Phonenumber { get; set; }
        public byte[]? Logo { get; set; }
        public string? OrganizationName { get; set; }
        public string? TaxNumber { get; set; }
        public RelationType RelationType { get; set; }
        public Languages Language { get; set; }
        public bool Blocked { get; set; }
        public string? Address { get; set; }
        public string? AddressZIP { get; set; }
        public string? AddressCity { get; set; }
        public string? Website { get; set; }
        public DateTime? BlockedDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IBAN { get; set; }         
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual bool Deleted { get; set; }
        public string? Title { get; set; } //title
        public string? InsurancePrefix { get; set; } //insurance_pr
        public string? InsuranceNo { get; set; } //insurance_no
        public int? Gender { get; set; } //gender
        public DateTime? LastVisitDate { get; set; } //ts_last_visit7
        public string? InsuranceType { get; set; } //insurance_type
        public string? InsuranceFrom { get; set; } //insurance_from
        public string? InsuranceFromNo { get; set; } //insurance_from_no

        List<string>? tags;

        public List<string>? Tags { get { return tags ??= new List<string>(); } set { tags = value; } }
    }
}
