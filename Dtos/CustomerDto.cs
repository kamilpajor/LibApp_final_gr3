using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        [Required]
        public DateTime? Birthdate { get; set; }
    }
}
