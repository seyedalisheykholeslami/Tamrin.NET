using Microsoft.AspNetCore.Mvc;
using Tamrin.Models;
using Tamrin.Services;

namespace Tamrin.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController(AuthService service) : ControllerBase
{
  [HttpPost("Login")]
   public ActionResult Login([FromBody]Login login)
   {
      var token = service.Login(login);
      Response.Cookies.Append("AuthToken", token.ToString());
      Response.Cookies.Append("Username", login.UserName);
       return Ok(token);
   }
   
   
   [HttpPost("Register")]
   public ActionResult Register([FromBody]Login login)
   {
       service.Register(login);
       return Ok();
   }
}