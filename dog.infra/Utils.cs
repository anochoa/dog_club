namespace dog.infra;

public static class Utils
{
    public static int EvitandoThrottlingExceptionDaAPI {
        get
        {
            Random random = new Random();
            int randomThrottlingSeconds = random.Next(1, 10).Config();
            return randomThrottlingSeconds;
        }
    }
}