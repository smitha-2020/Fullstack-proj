namespace backend.src.DTOs;

public class DTORole
{
    public string Email { set; get; } = null!;
    public string RoleName { set; get; } = null!;
    public bool IsCustomer { get; set; }
}