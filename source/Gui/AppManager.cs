using System.Collections.Generic;
using Cosmos.System.Graphics;
namespace Oceano.Gui
{
    public class AppManager
    {
        public static List<App> apps = new();
        public static void RegisterApp(App app, Bitmap icon)
        {
            apps.Add(app);
            app.icon = icon;
        }
        public static void DeleteApp(App app)
        {
            apps.Remove(app);
        }
        public static void DeleteAllApps()
        {
            apps.Clear();
        }
        public static void SetIcon(Bitmap icon, App app)
        {
            app.icon = icon;
        }
    }
}