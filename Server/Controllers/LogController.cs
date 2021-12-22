using Microsoft.AspNetCore.Mvc;
using New2ndSemester.Shared;

namespace New2ndSemester.Server.Controllers;


[ApiController]
[Route("api/logs/")]

public class LogController
{

    private PgContext _db;  
    private readonly ILogger<ShiftController> _logger;
    
    public LogController(ILogger<ShiftController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }
    
    [HttpGet("all")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<Log> AllLogs()
    {
        var query = from log in _db.logs select log;
        return query.ToArray();
    }

    [HttpPost("authenticate")]
    public ActionResult AuthenticateRecentLog(int user_id)
    {
        var _log = _db.logs.OrderBy(log => log.id).Last();
        _log.by_user_id = user_id;
        _db.Update(_log);
        _db.SaveChanges();
        
        return new OkResult();
    }
}
