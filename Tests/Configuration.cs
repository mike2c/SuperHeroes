using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class Configuration
    {
        private static IConfiguration Instance;        
        public static IConfiguration GetInstance()
        {
            if(Instance is null)
            {
                Instance = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }
            
            return Instance;
        }
    }
}
