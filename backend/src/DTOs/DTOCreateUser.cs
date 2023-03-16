using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using backend.src.Models;

namespace backend.src.DTOs;

public class DTOCreateUser
{
   
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}

