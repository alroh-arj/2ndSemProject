using Microsoft.AspNetCore.Mvc;
using New2ndSemester.Shared;
using Npgsql;

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

        var _user = query.FirstOrDefault<User>();

        if (_user == null)
            return NotFound("Brugeren eksisterer ikke");
        
        bool verified = BCrypt.Net.BCrypt.Verify(loginUser.password, _user.password);

        if (!verified)
            return BadRequest("Kodeordet er forkert");
        
        _user.password = "";
        return Ok(_user);
    }
    
    [HttpPost("register")]
    public ActionResult<User> Register(User registerUser)
    {
        // check database for user
        var query = from user in _db.users
            where user.username == registerUser.username
            select user;


        if (query.FirstOrDefault<User>() != null)
            return BadRequest("Brugernavnet er optaget");
        
        _db.users.Add(registerUser);
        _db.SaveChanges();
        
        registerUser.password = "";
    
        return Ok(registerUser);
    }
    [HttpDelete("{user_id:int}")]
    public ActionResult<User> Delete(int user_id)
    {
        // check database for user
        var query = from user in _db.users
            where user.id == user_id
            select user;


        var _user = query.FirstOrDefault<User>();
        
        if (_user == null)
            return BadRequest("Brugernavnet findes ikke");
        
        _db.users.Remove(_user);
        _db.SaveChanges();
        
        _user.password = "";
    
        return Ok();
    }
    
    [HttpGet("all")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<User> All()
    {
        var query = from user in _db.users
            select user;

        return query.ToArray();
    }

    [HttpPost("{user_id:int}/update")]
    public ActionResult<User> Update(int user_id, User updateUser)
    {
        var query = from user in _db.users
            where user.id == user_id
            select user;

        var _user = query.FirstOrDefault<User>();
        
        if (_user == null)
            return NotFound("Brugeren findes ikke");

        _user.full_name = updateUser.full_name;
        _user.username = updateUser.username;
        _user.description = updateUser.description;
        
        _db.users.Update(_user);
        _db.SaveChanges();
        
        _user.password = "";
    
        return Ok(_user);
    }

    [HttpGet("{user_id:int}")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public ActionResult<User> Get(int user_id)
    {
        // check database for user
        var query = from user in _db.users
            where user.id == user_id
            select user;

        var _user = query.FirstOrDefault<User>();
        
        if (_user == null)
            return NotFound("Brugeren findes ikke");
        
        _user.password = "";
    
        return Ok(_user);
    }

    [HttpGet("{user_id:int}/roles")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<Role> Roles(int user_id)
    {
        var query = from user_role in _db.user_roles
            join role in _db.roles on user_role.role_id equals role.id
            where user_role.user_id == user_id
            select role;

        return query.ToArray();
    }
}
