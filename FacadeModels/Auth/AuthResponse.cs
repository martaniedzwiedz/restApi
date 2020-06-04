using Newtonsoft.Json;

namespace project_test.FacadeModels.Auth
{
    public class AuthResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string Token {get; set;}
    }
}