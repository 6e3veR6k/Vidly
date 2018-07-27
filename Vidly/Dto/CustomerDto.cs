using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string ImgPath { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public DateTime RegisteredDate { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }
    }
}