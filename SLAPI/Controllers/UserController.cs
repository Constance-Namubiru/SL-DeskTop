using Microsoft.AspNetCore.Mvc;
using SLData.Shared;
using System.Net;

namespace SLAPI.Controllers
{
    [ApiController]
    [Route("/login")]
    public class UserController : ControllerBase
    {


        public List<User> users = new List<User>() 
        
        {
              
         new User{ Email="connie.kigongo@gmail.com", Password="mypassword"},
         
         new User{ Email="maria.mugisha@gmail.com", Password="12345"},

         new User{ Email="alexm.tendo@gmail.com", Password="qwerty"},






        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Login")]
        public string Login(User user)
        {
            var founduser = users.Where(u=>u.Email == user.Email.Trim() &&
            u.Password == user.Password.Trim()).FirstOrDefault();

            if(founduser != null)
            {

                return "Login success";

            }

            else

            return "Invalid user name or password";

        }
    }
}