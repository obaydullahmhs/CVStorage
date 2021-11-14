using CVStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVStorage.Controllers
{
    public class UserController : Controller
    {
        private readonly IPersonRepo _personRepository;


        public UserController(IPersonRepo personRepo)
        {
            _personRepository = personRepo;
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
    }
}
