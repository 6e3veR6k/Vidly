using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Customer name")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Subscriber")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Member")]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }
    }
}