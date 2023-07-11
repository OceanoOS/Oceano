using System.Drawing;

namespace Oceano.GUI.Themes;

public class Theme
{
    /// <summary>
    ///     Background color.
    /// </summary>
    public Color Background;

    /// <summary>
    ///     Click color.
    /// </summary>
    public Color Click;

    /// <summary>
    ///     Foreground color.
    /// </summary>
    public Color Foreground;

    /// <summary>
    ///     Hover color.
    /// </summary>
    public Color Hover;

    /// <summary>
    ///     Primary color.
    /// </summary>
    public Color Primary;

    /// <summary>
    ///     Secondary color.
    /// </summary>
    public Color Secondary;

    /// <summary>
    ///     Initialize a new theme.
    /// </summary>
    /// <param name="background">Background color.</param>
    /// <param name="foreground">Foreground color</param>
    /// <param name="primary">Primary color.</param>
    /// <param name="secondary">Secondary color.</param>
    /// <param name="hover">Hover color.</param>
    /// <param name="click">Click color.</param>
    public Theme(Color background, Color foreground, Color primary, Color secondary, Color hover, Color click)
    {
        Background = background;
        Foreground = foreground;
        Primary = primary;
        Secondary = secondary;
        Hover = hover;
        Click = click;
    }
}