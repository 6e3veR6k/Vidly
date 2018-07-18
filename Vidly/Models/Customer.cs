using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}