using Microsoft.AspNetCore.Mvc;
using New2ndSemester.Shared;

namespace New2ndSemester.Server.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private PgContext _db;  
    private readonly ILogger<UserController> _logger;
    
    public UserController(ILogger<UserController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpPost("login")]
    public ActionResult<User> Login(User loginUser)
    {

        // check database for user
        var query = from user in _db.users
            where user.username == loginUser.username
            select user;

        User _user;
        
        try {
            _user = query.First<User>();
        }
        catch (InvalidOperationException e)
        {
            return NotFound("Brugeren eksisterer ikke");
        }
        
        bool verified = BCrypt.Net.BCrypt.Verify(loginUser.password, _user.password);

        if (!verified)
        {
            return BadRequest("Kodeordet er forkert");
        }
        
        _user.password = "";
        return Ok(_user);
    }
    
    [HttpPost("register")]
    public ActionResult<User> Register(User registerUser)
    {
        _db.users.Add(registerUser);
        _db.SaveChanges();

        registerUser.password = "";
        
        return Ok(registerUser);

        // try
        // {
        //     var user = query.First<User>();
        //     user.password = "";
        //     return Ok(user);
        // }
        // catch (InvalidOperationException e)
        // {
        //     return NotFound("Brugernavn eller kodeord er forkert");
        // }
    }
}
