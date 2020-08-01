using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.Post
{
    public class File
    {
        [Required]
        public IFormFile file { get; set; }
    }
}
