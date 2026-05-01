using System.ComponentModel.DataAnnotations;
using FUMCFoodPantry.Models.Enums;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    [Required]
    public UserRole Role { get; set; }

    public DateTime DateJoined { get; set; }


    public string AdditionalInformation {get; set; }
    
}