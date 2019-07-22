using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string UserId { get; set; }
  }

  public class VaultKeeps
  {
    public int Id { get; set; }

    public int VaultId { get; set; }

    public int KeepId { get; set; }

    public string UserId { get; set; }
  }
}








// id int NOT NULL AUTO_INCREMENT,
// name VARCHAR(20) NOT NULL,
// description VARCHAR(255) NOT NULL,
// userId VARCHAR(255),