using Oceano.Gui.Apps;
using PrismGraphics;
using System.Collections.Generic;

namespace Oceano.Gui
{
    public class AppManager
    {
        public static List<App> apps = new();
        public static Terminal terminal = new(false, 400, 300, 50, 50);
        public static Settings settings = new(false, 400, 300, 40, 40);
        public static void RegisterApp(App app, byte[] icon)
        {
            app.icon = Image.FromBitmap(icon);
            apps.Add(app);
        }
        public static void RemoveApp(App app)
        {
            apps.Remove(app);
            app.icon = null;
        }
        public static void Init()
        {
            RegisterApp(settings, Core.Resources.settings);
            RegisterApp(terminal, Core.Resources.terminal);
        }
    }
}
