using Cosmos.System;
<<<<<<< Updated upstream
using Oceano.Core.Drivers;
=======
<<<<<<< HEAD
using Cosmos.System.Graphics;
using Oceano.GUI;
=======
using Oceano.Core.Drivers;
>>>>>>> main
>>>>>>> Stashed changes

namespace Oceano.Core;

public class Program : Kernel
{
    #region Fields
<<<<<<< Updated upstream
    public static VMWareSVGAII vMWareSVGAII { get; set; }
=======
<<<<<<< HEAD

    public static Canvas Canvas { get; set; }

=======
    public static VMWareSVGAII vMWareSVGAII { get; set; }
>>>>>>> main
>>>>>>> Stashed changes
    #endregion

    #region Methods

    protected override void BeforeRun()
    {
<<<<<<< Updated upstream
        
=======
<<<<<<< HEAD
        Graphics.Initialize();
=======
        
>>>>>>> main
>>>>>>> Stashed changes
    }

    protected override void Run()
    {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
        Graphics.Update();
=======
>>>>>>> main
>>>>>>> Stashed changes
    }

    #endregion
}