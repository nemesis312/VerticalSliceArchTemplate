namespace VerticalSliceArch.Domain.DTOs;

public class UserDto
{
    public UserDto(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
}