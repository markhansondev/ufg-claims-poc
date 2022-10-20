
namespace Poc.Claims.Utils
{

    public static class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
            //DomainEvents.Init();
        }
    }
}
