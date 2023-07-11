using Cosmos.System;

namespace Oceano.GUI;

/// <summary>
///     Control class, used for drawing
/// </summary>
public class Control
{
    /// <summary>
    ///     Height of the control
    /// </summary>
    public int height;

    /// <summary>
    ///     Status of the cursor.
    /// </summary>
    public CursorStatus status;

    /// <summary>
    ///     Width of the control
    /// </summary>
    public int width;

    /// <summary>
    ///     x position of the control
    /// </summary>
    public int x;

    /// <summary>
    ///     y position of the control
    /// </summary>
    public int y;

    /// <summary>
    ///     Initialize a new control
    /// </summary>
    /// <param name="x">x position of the control</param>
    /// <param name="y">y position of the control</param>
    public Control(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    /// <summary>
    ///     Update the control.
    /// </summary>
    public void Update()
    {
        if ((MouseManager.X >= x) & (MouseManager.X <= x + width) & (MouseManager.Y >= y) &
            (MouseManager.Y <= y + height))
        {
            if (MouseManager.MouseState == MouseState.Left)
                status = CursorStatus.Click;
            else
                status = CursorStatus.Hover;
        }
        else
        {
            status = CursorStatus.None;
        }

        Render();
    }

    /// <summary>
    ///     Render the control.
    /// </summary>
    public virtual void Render()
    {
    }
}

public enum CursorStatus
{
    None = 0,
    Hover = 1,
    Click = 2
}