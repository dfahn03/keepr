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

    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
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

    public string Delete(int id)
    {
      string query = "DELETE FROM vaults WHERE id =@Id";
      int rowAffected = _db.Execute(query, new { id });
      if (rowAffected < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Vault";
    }
  }
}