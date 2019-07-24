using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    // public IEnumerable<Vault> GetAll()
    // {
    //   return _db.Query<Vault>("SELECT * FROM vaults");
    // }

    public IEnumerable<Vault> GetVaultsByUser(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId");
    }

    public Vault GetById(int id)
    {
      string query = "SELECT * FROM vaults WHERE id = @Id";
      Vault data = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (data == null) throw new Exception("Invalid Id");
      return data;
    }

    public Vault Create(Vault value)
    {
      string query = @"
      INSERT INTO vaults (name, description, userId) 
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();      
      ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Vault Update(Vault value)
    {
      string query = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        userId = @UserId
      WHERE id = @Id;
      SELECT * FROM vaults WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Vault>(query, value);
    }

    public string Delete(int id, string userId)
    {
      string query = "DELETE FROM vaults WHERE id =@Id AND userId = @UserId";
      int rowAffected = _db.Execute(query, new { id });
      if (rowAffected < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Vault";
    }

    public string AddKeepToVault(VaultKeeps vk)
    {
      var userId = vk.UserId;
      string query = @"
      INSERT INTO vaultkeeps (vaultId, keepId, userId) 
      VALUES (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();      
      ";
      int rowsAffected = _db.Execute(query, vk);
      if (rowsAffected < 1) throw new Exception("Invalid Ids");
      return "Successfully add Keep to Vault";
      // int id = _db.ExecuteScalar<int>(query, value);
      // value.Id = id;
      // return value;
    }

    public IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      string query = @"
      SELECT *FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE vaultId = @id
      ";
      return _db.Query<Keep>(query, new { id });
    }

    public string DeleteVaultKeep(VaultKeeps value)
    {
      string query = @"DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId;";
      int rowsAffected = _db.Execute(query, value);
      if (rowsAffected < 1) throw new Exception("Invalid Ids");
      return "Successfully Deleted VaultKeep";
    }
  }
}