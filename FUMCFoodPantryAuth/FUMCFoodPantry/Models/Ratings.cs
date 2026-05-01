using System.ComponentModel.DataAnnotations;

public class Ratings
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Score { get; set;}
    [Required]
    public DateTime Date { get; set;}
    [Required]
    public int MemberId { get; set;}

}