using System.ComponentModel.DataAnnotations;

namespace APBD_04.Model;

public class Product
{
    [Required] public int IdProduct { get; set; }
    [Required] public int IdWarehouse { get; set; }
    [Required] public int Amount { get; set; }
    [Required] public string CreatedAt { get; set; }
}