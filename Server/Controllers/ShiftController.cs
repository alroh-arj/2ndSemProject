using Microsoft.AspNetCore.Mvc;
using New2ndSemester.Shared;

namespace New2ndSemester.Server.Controllers;

[ApiController]
[Route("api/")]
public class ShiftController : Controller
{
    private PgContext _db;  
    private readonly ILogger<ShiftController> _logger;
    
    public ShiftController(ILogger<ShiftController> logger, PgContext db)
    {
        _logger = logger;
        _db = db;
    }
    
    [HttpGet("shift/all")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<ExtendedShift> AllShifts()
    {
        var query = from shift in _db.shifts 
            select new ExtendedShift
            {
                shift = shift,
                location = (
                    from location in _db.locations
                    where shift.location_id == location.id
                    select location
                ).First(),
                assigned_volunteers = (
                    from user_shift in _db.user_shifts
                    join user in _db.users on user_shift.user_id equals user.id
                    where user_shift.shift_id == shift.id
                    select user
                    // from user_shift in _db.user_shifts
                    // where user_shift.shift_id == shift.id
                    // select user_shift
                ).ToArray()
            };

        return query.ToArray();
    }
    
    
    [HttpGet("shift/{shift_id:int}")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public ExtendedShift? GetShifts(int shift_id)
    {
        var query = from shift in _db.shifts
            where shift.id == shift_id
            select new ExtendedShift
            {
                shift = shift,
                location = (
                    from location in _db.locations
                    where shift.location_id == location.id
                    select location
                ).First(),
                assigned_volunteers = (
                    from user_shift in _db.user_shifts
                    join user in _db.users on user_shift.user_id equals user.id
                    where user_shift.shift_id == shift.id
                    select user
                ).ToArray()
            };

        return query.FirstOrDefault();
    }
    
    [HttpGet("user_shift/")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<UserShift> UserShifts(int user_id)
    {
        var query = from user_shift in _db.user_shifts
            where user_shift.user_id == user_id
            select user_shift;

        return query.ToArray();
    }
    
    [HttpGet("user_shift/all")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<UserShift> AllUserShifts()
    {
        var query = from user_shift in _db.user_shifts select user_shift;

        return query.ToArray();
    }
    
    [HttpPost("user_shift/")]
    public ActionResult Assign(UserShift user_shift)
    {
        _db.user_shifts.Add(user_shift);
        _db.SaveChanges();
        
        return Ok();
    }
    [HttpDelete("shift/{shift_id:int}/{user_id:int}")]
    public ActionResult Unassign(int shift_id, int user_id)
    {
        _db.Remove(_db.user_shifts.First(e => e.user_id == user_id && e.shift_id == shift_id));
        _db.SaveChanges();
        
        return Ok();
    }

    [HttpPost("shift/")]
    public ExtendedShift Set(Shift shift)
    {
        shift.start = shift.start.ToUniversalTime();
        shift.stop = shift.stop.ToUniversalTime();
        
        if (shift.id == null)
        {
            shift = _db.Add(shift).Entity;
        }
        else
        {
            shift = _db.Update(shift).Entity;
        }

        var eshift = new ExtendedShift
        {
            shift = shift,
            location = (
                from location in _db.locations
                where shift.location_id == location.id
                select location
            ).First(),
            assigned_volunteers = (
                from user_shift in _db.user_shifts
                join user in _db.users on user_shift.user_id equals user.id
                where user_shift.shift_id == shift.id
                select user
            ).ToArray()
        };
        
        _db.SaveChanges();
        return eshift;
    }
    
    [HttpGet("location/all")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public IEnumerable<Location> AllLocations()
    {
        var query = from location in _db.locations select location;

        return query.ToArray();
    }
    
    // [HttpPost("shift/{shift_id:int}")]
    // public ActionResult<Shift> Create(int shift_id, Shift shift)
    // {
    //     shift = _db.Add(shift).Entity;
    //     _db.SaveChanges();
    //     return Ok(shift);
    // }
}
