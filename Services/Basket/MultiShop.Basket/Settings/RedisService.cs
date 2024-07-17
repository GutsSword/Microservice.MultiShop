using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private readonly string host;
        private readonly int port;

        private ConnectionMultiplexer connectionMultiplexer;

        public RedisService(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect($"{host}:{port}");
        public IDatabase Getdb(int db = 1) => connectionMultiplexer.GetDatabase(0);

    }
}
