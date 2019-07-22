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

  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }

    // //api/vaults
    // [Authorize]
    // [HttpGet]
    // public ActionResult<IEnumerable<Vault>> GetAll()
    // {
    //   try
    //   {
    //     return Ok(_repo.GetAll());
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    //api/vaults
    [Authorize]
    [HttpGet]
    public ActionResult<Vault> GetVaultsByUser(string userId)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        userId = uid;
        return Ok(_repo.GetVaultsByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/vaults/:id
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
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

    //api/vaults
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
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

    //api/vaults/:id
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
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

    //api/vaults/:id
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