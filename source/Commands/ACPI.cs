namespace Oceano.Commands
{
    public class ACPI
    {
        public static void Shutdown()
        {
            Cosmos.System.Power.Shutdown();
            Cosmos.Core.ACPI.Shutdown();
        }
        public static void Reboot()
        {
            Cosmos.System.Power.Reboot();
            Cosmos.Core.ACPI.Reboot();
        }
    }
}