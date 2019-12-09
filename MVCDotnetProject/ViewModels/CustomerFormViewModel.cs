using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDotnetProject.Models;

namespace MVCDotnetProject.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}