namespace CAR.Parques.App.WebMvc.Core.Token
{
    public class JsonWebToken
    {
        public string access_Token { get; set; }
        public string token_Type { get; set; } = "bearer";
        public int expires_in { get; set; }
        public string refresh_Token { get; set; }
    }
}