public class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpireDate { get; set; }
}