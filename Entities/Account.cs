namespace Accounts.Entities;

public class Account
{
    public int AccountId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public string? Cards { get; set; }
}