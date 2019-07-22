using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _repo;
    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    //api/keeps

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAllPublicKeeps()
    {
      try
      {
        return Ok(_repo.GetAllPublicKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/keeps/user
    [Authorize]
    [HttpGet("user")]
    public ActionResult<Keep> GetKeepsByUser(string userId)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        userId = uid;
        return Ok(_repo.GetKeepsByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    //api/keeps/:id
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    //api/keeps
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        value.UserId = uid;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/keeps/:id
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        value.UserId = uid;
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/keeps/:id
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}