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
    public ActionResult<IEnumerable<Vault>> GetVaultsByUser(string userId)
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
        string uid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Delete(id, uid));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }




    //api/vaults/:id/keeps
    [Authorize]
    [HttpPost("{id}/keeps")]
    public ActionResult<String> AddKeepToVault(int id, [FromBody] VaultKeeps vaultKeeps)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        vaultKeeps.UserId = uid;
        vaultKeeps.VaultId = id;
        return Ok(_repo.AddKeepToVault(vaultKeeps));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/vaults/:id/keeps
    [Authorize]
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int id)
    {
      try
      {
        return Ok(_repo.GetKeepsByVaultId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //api/vaults/:id/keeps
    [Authorize]
    [HttpPut("{id}/keeps")]
    public ActionResult<string> DeleteVaultKeep(int id, [FromBody] VaultKeeps value)
    {
      try
      {
        var uid = HttpContext.User.FindFirstValue("Id");
        value.UserId = uid;
        value.Id = id;
        return Ok(_repo.DeleteVaultKeep(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}