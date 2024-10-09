namespace Investify.MVVM.Model.Config
{
    public class Config
    {
        public ServerConfig ServerConfig { get; set; } = new();
        public ApiKeys ApiKeys { get; set; } = new();
    }
}
