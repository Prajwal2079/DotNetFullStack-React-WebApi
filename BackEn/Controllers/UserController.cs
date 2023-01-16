using Microsoft.AspNetCore.Mvc;
using User.Model;
using Microsoft.AspNetCore.Cors;
using User.DAL;

namespace BackEn.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors]
    public IEnumerable<Users> GetAllUsers()
    {
        List<Users> allList = new List<Users>();
        allList = UserDataAccess.GetAllUser();
        return allList;
    }

    [Route("{id}")]
    [HttpGet]
    [EnableCors]
    public ActionResult<Users> GetUserById(int id){
        Users user = UserDataAccess.GetUserById(id);
        return user;
    }
}
