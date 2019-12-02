namespace DanceCoolDTO
{
    public class AuthorizationUserIdentityDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthorizationUserIdentityDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
