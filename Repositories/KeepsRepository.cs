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

    public IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 'false'");
    }

    public IEnumerable<Keep> GetKeepsByUser(string userId)
    {
      var UserId = userId;
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = UserId");
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
      INSERT INTO keeps (name, description, userId, img, isPrivate) VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
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
        img = @Img,
        isPrivate = @IsPrivate,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
      WHERE id = @Id AND userId = @UserId;
      SELECT * FROM keeps WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    internal object UpdateKeepCounts(Keep value)
    {
      string query = @"
      UPDATE keeps
      SET
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
      WHERE id = @Id;
      SELECT * FROM keeps WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id, string userId)
    {
      string query = "DELETE FROM keeps WHERE id =@Id AND userId= @UserId";
      int rowAffected = _db.Execute(query, new { id, userId });
      if (rowAffected < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Keep";
    }

  }
}