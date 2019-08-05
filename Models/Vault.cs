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