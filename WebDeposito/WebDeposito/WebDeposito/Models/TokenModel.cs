namespace WebDeposito.Models
{
    public class TokenModel
    {
        public UserModel Usuario { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }
    }
}
