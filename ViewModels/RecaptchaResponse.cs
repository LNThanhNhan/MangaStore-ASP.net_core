using Newtonsoft.Json;

namespace MangaStore.ViewModels;

public class RecaptchaResponse
{
    public bool Success { get; set; }
    [JsonProperty("error-codes")]
    public List<string> ErrorCodes { get; set; }
    [JsonProperty("challenge_ts")]
    public DateTime ChallengeTs { get; set; }
    public string Hostname { get; set; }
    public Double Score { get; set; }
    public string Action { get; set; }
}