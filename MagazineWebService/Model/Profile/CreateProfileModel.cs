using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.Profile
{
    public class CreateProfileModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<string> SlidShow { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<string> Link { get; set; }
        public int? AccreditationNumber { get; set; }
    }
}
