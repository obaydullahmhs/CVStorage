using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.ViewModels
{
    public class PersonEditViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string University { get; set; }

        public double SSC_GPA { get; set; }

        public double HSC_GPA { get; set; }

        public double Bachelor_CGPA { get; set; }

        public string Project { get; set; }

        public string Skills { get; set; }

        public IFormFile PhotoPath { get; set; } 

        public bool IsAccepted { get; set; }

        public string ExistingPhotoPath { get; set; }
    }
}
