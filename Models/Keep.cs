using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string UserId { get; set; }

    // public int VaultId { get; set; }

    public string Image { get; set; }

    [Required]
    public bool IsPrivate { get; set; }

    public int Views { get; set; }

    public int Shares { get; set; }

    public int Keeps { get; set; }
  }
}


// id int NOT NULL AUTO_INCREMENT,
// name VARCHAR(20) NOT NULL,
// description VARCHAR(255) NOT NULL,
// userId VARCHAR(255),
// img VARCHAR(255),
// isPrivate TINYINT,
// views INT DEFAULT 0,
// shares INT DEFAULT 0,
// keeps INT DEFAULT 0,