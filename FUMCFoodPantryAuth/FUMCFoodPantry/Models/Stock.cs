using System.ComponentModel.DataAnnotations;

public class Stock
{
    public int Id { get; set; }

    [Required]
    public string Item { get; set; }

    [Range(0,int.MaxValue)]
    public int Quantity { get; set; }
    public double AverageRating { get; set; }
    public int Served { get; set; }
    public DateTime Date { get; set; }

    [Range(0,5)]
    public int Rating { get; set;}
}