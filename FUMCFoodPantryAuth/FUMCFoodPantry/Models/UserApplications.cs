using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(MemberId), IsUnique = true)]
public class UserApplications
{
    public int Id { get; set; }
    public int MemberId { get; set;}
    public DateTime Date { get; set;} = DateTime.Now;
    [Required]
    public string FirstName { get; set;}
    public string? MiddleName { get; set;}
    [Required]
    public string LastName { get; set;}
    [Required]
    public string Address { get; set;}
    [Required]
    public String FixedAddress { get; set;}
    [Required]
    public String City { get; set;}
    [Required]
    [StringLength(2, MinimumLength = 2)]
    [RegularExpression("^[A-Z]{2}$", ErrorMessage = "State must be a valid 2-letter abbreviation.")]
    public string State { get; set;}
    [Required]
    public int Zip { get; set;}
    [Required]
    public string County { get; set;}
    [Required]
    public string Phone { get; set;}

    [Required]
    public DateOnly Birthday { get; set;}
    [Required]
    public String EmploymentStatus { get; set;}
    [Required]
    public String HosuingStatus { get; set;}
    [Required]
    public String PrimaryContact { get; set;}
    [Required]
    public String Gender { get; set;}
    [Required]
    public String Race { get; set;}

    public String Household { get; set;}
    [Required]
    public String Disability { get; set;}
    [Required]
    public String Military { get; set;}
    [Required]
    public String Vetran { get; set;}
    [Required]
    public String Snap { get; set;}

    public String? Family1Name { get; set;}
    public DateOnly? Family1Birthday { get; set;}
    public String? Family1Ethnicity { get; set;}
    public String? Family1Gender { get; set;}
    public String? Family1Relationship { get; set;}
    public int? Family1Income { get; set;}
      public String? Family2Name { get; set;}
    public DateOnly? Family2Birthday { get; set;}
    public String? Family2Ethnicity { get; set;}
    public String? Family2Gender { get; set;}
    public String? Family2Relationship { get; set;}
    public int? Family2Income { get; set;}
    public String? Family3Name { get; set;}
    public DateOnly? Family3Birthday { get; set;}
    public String? Family3Ethnicity { get; set;}
    public String? Family3Gender { get; set;}
    public String? Family3Relationship { get; set;}
    public int? Family3Income { get; set;}
    public String? Family4Name { get; set;}
    public DateOnly? Family4Birthday { get; set;}
    public String? Family4Ethnicity { get; set;}
    public String? Family4Gender { get; set;}
    public String? Family4Relationship { get; set;}
    public int? Family4Income { get; set;}
    public String? Family5Name { get; set;}
    public DateOnly? Family5Birthday { get; set;}
    public String? Family5Ethnicity { get; set;}
    public String? Family5Gender { get; set;}
    public String? Family5Relationship { get; set;}
    public int? Family5Income { get; set;}


   
}