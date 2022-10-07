namespace Oceano.Commands
{
    public class power
    {
        public static void Shutdown()
        {
            Cosmos.System.Power.Shutdown();
            Cosmos.System.Power.QemuShutdown();
        }
        public static void Reboot()
        {
            Cosmos.System.Power.Reboot();
            Cosmos.System.Power.QemuReboot();
        }
    }
}
