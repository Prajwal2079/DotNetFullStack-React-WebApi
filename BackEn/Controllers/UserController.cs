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
    [EnableCors()]
    public IEnumerable<Users> GetAllUsers()
    {
        List<Users> allList = new List<Users>();
        allList = UserDataAccess.GetAllUser();
        return allList;
    }

    [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<Users> GetUserById(int id){
        Users user = UserDataAccess.GetUserById(id);
        return user;
    }

[HttpPost]
[EnableCors()]
public ActionResult InsertUser(Users user){
    UserDataAccess.InsertUser(user);
    return Ok(new {message="Data inserted"});
}

[EnableCors()]
[HttpDelete]
[Route("{id}")]
public ActionResult DeleteUserById(int id){
    UserDataAccess.DeleteById(id);
    return Ok(new{message = "Data deleted"});
}

[EnableCors()]
[HttpPut]
public ActionResult UpdateUser(Users user){
    UserDataAccess.UpdateById(user);
    return Ok(new {message = "User updated"});
}


}

