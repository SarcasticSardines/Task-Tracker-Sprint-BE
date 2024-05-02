using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasksprintbe.Models;
using tasksprintbe.Models.DTO;
using tasksprintbe.Services;

namespace tasksprintbe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService data){
            _data = data;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User){
            return _data.Login(User);
        }

        [HttpPost]
        [Route("AddUser")]

        public bool AddUser(CreateAccDTO UserToAdd){
            return _data.AddUser(UserToAdd);
        }

        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]

        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }

        [HttpGet]
        [Route("GetUserByDate")]

        public IEnumerable<UserModel> GetUserByDate(string date){
            return _data.GetUserByDate(date);
        }
    }
}