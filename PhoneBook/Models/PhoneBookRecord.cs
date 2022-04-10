using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PhoneBookRecord
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int AreaID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
