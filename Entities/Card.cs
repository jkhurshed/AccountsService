namespace Accounts.Entities;

public class Card
{
    public int Id { get; set; }
    public string PanNumber { get; set; }
    public int Cvv { get; set; }
    public int ExpMonth { get; set; }
    public int ExpYear { get; set; }
    public string? CardHolder { get; set; }
}