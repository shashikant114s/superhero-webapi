using System.ComponentModel.DataAnnotations;

namespace SuperHeros.Entities
{
    public class User
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
    }
}
