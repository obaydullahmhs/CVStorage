using CVStorage.Models;
using CVStorage.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Controllers
{
    public class UserController : Controller
    {
        private readonly IPersonRepo _personRepository;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public UserController(IPersonRepo personRepo, IHostingEnvironment hostingEnvironment)
        {
            _personRepository = personRepo;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult AllUsers()
        {
            var model = _personRepository.GetAllPersons();
            return View(model);
        }

        public IActionResult Profile(string ID)
        {
            Person model = _personRepository.GetPerson(ID);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string ID)
        {
            Person person = _personRepository.GetPerson(ID);
            PersonEditViewModel personEditViewModel = new PersonEditViewModel
            {
                ID = person.ID,
                Name = person.Name,
                Email = person.Email,
                Subject = person.Subject,
                University = person.University,
                SSC_GPA = person.SSC_GPA,
                HSC_GPA = person.HSC_GPA,
                Bachelor_CGPA = person.Bachelor_CGPA,
                Project = person.Project,
                Skills = person.Skills,
                ExistingPhotoPath = person.PhotoPath,
                Phone = person.Phone,
                IsAccepted = person.IsAccepted,

            };
            return View(personEditViewModel);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Edit(PersonEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = _personRepository.GetPerson(model.ID);
                person.Name = model.Name;
                person.Email = model.Email;
                person.Subject = model.Subject;
                person.University = model.University;
                person.SSC_GPA = model.SSC_GPA;
                person.HSC_GPA = model.HSC_GPA;
                person.Bachelor_CGPA = model.Bachelor_CGPA;
                person.Phone = model.Phone;
                person.Project = model.Project;
                person.Skills = model.Skills;
                person.IsAccepted = model.IsAccepted;

                if (model.PhotoPath != null)
                {
                    //if (model.ExistingPhotoPath != null)
                    //{
                    //    string filePath = Path.Combine(IHostingEnvironment.WebRootPath,
                    //        "images", model.ExistingPhotoPath);
                    //    System.IO.File.Delete(filePath);
                    //}
                    person.PhotoPath = ProcessUploadedFile(model);
                }

                Person updatedPerson = _personRepository.Update(person);

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(model);
        }

        [Obsolete]
        private string ProcessUploadedFile(PersonEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.PhotoPath != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoPath.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }
}
