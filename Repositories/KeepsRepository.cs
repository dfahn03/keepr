using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Keep GetById(int id)
    {
      string query = "SELECT * FROM keeps WHERE id = @Id";
      Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (data == null) throw new Exception("Invalid Id");
      return data;
    }

    public Keep Create(Keep value)
    {
      string query = @"
      INSERT INTO keeps (name, description, image, isPrivate) VALUES (@Name, @Description, @Image, @IsPrivate);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Keep Update(Keep value)
    {
      string query = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        userId = @UserId,
        image = @Image,
        private = @Private,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
      WHERE id = @Id;
      SELECT * FROM keeps WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM keeps WHERE id =@Id";
      int rowAffected = _db.Execute(query, new { id });
      if (rowAffected < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Keep";
    }
  }
}