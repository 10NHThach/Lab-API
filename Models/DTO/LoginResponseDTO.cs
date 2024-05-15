namespace LabAPI.Models.DTO
{
    public class LoginResponseDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string JwtToken { set; get; }
    }
}
