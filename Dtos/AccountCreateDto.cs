namespace Accounts.Dtos;

public class AccountCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public List<string>? Cards { get; set; }
}