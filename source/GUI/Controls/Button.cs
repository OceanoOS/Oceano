using System.Drawing;
using Cosmos.System.Graphics.Fonts;
using Oceano.GUI.Themes;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI.Controls;

public class Button : Control
{
    public enum ColorPriority
    {
        Primary = 1,
        Secondary = 2
    }

    private Color Bg;
    public PCScreenFont Font;
    private ColorPriority Priority;
    private string Text;
    private Theme Theme;

    public Button(int x, int y, int width, int height, string text, Theme theme, ColorPriority priority,
        PCScreenFont font) : base(x, y,
        width, height)
    {
        Text = text;
        Theme = theme;
        Font = font;
        Priority = priority;
    }

    public override void Render()
    {
        Kernel.Canvas.DrawFilledRectangle(Bg, x, y, width, height);
        Kernel.Canvas.DrawString(Text, PCScreenFont.Default, Theme.Foreground, x + 2, y + 2);
        switch (Priority)
        {
            case ColorPriority.Primary:
                Kernel.Canvas.DrawRectangle(Theme.Primary, x, y, width, height);
                break;
            case ColorPriority.Secondary:
                Kernel.Canvas.DrawRectangle(Theme.Secondary, x, y, width, height);
                break;
        }

        if (status == CursorStatus.Hover)
        {
            if (status == CursorStatus.Click)
            {
                Bg = Theme.Click;
            }
            else
            {
                Bg = Theme.Hover;
            }
        }
        else
        {
            Bg = Theme.Background;
        }
    }
}