using System;
using System.Collections.Generic;
using System.Numerics;

namespace PrismGraphics.Rasterizer
{
	/// <summary>
	/// The <see cref="Engine"/> class - It is used to render 3D scenes onto a 2D canvas.
	/// <list type="table">
	/// <item>See also: <seealso cref="Triangle"/></item>
	/// <item>See also: <seealso cref="Camera"/></item>
	/// <item>See also: <seealso cref="Light"/></item>
	/// <item>See also: <seealso cref="Mesh"/></item>
	/// </list>
	/// </summary>
	public class Engine : Graphics
	{
		/// <summary>
		/// Creates a new instance of the <see cref="Engine"/> class.
		/// </summary>
		/// <param name="Width">Width (in pixels) of the canvas.</param>
		/// <param name="Height">Height (in pixels) of the canvas.</param>
		/// <param name="FOV">The FOV (Field Of View) that the camera will have.</param>
		public Engine(ushort Width, ushort Height, float FOV) : base(Width, Height)
		{
			this.Height = Height;
			this.Width = Width;

			SkyColor = Color.GoogleBlue;
			Lights = new();
			Objects = new();
			Camera = new(FOV);
			Gravity = 1f;
			Zoom = 0f;
		}

		#region Methods

		/// <summary>
		/// Renders the whole scene onto the internal canvas.
		/// You must draw this object as an image on another canvas to show the output.
		/// </summary>
		public void Render()
		{
			// Create the camera rotation matrix - This is separate from the object rotation.
			Quaternion CameraQ = Camera.GetRotationQuaternion();

			// Create a new projection value. This is equivalent to using a projection matrix, but it is easier.
			float Translator = (float)(Width / 2 / Math.Tan((Camera.FOV + Zoom) / 2 * 0.0174532925)); // 0.0174532925 == pi / 180

			// Set the sky color - Make sure to adjust for ambiant color aswell.
			Clear(Color.Normalize(SkyColor) * Camera.Ambient);

			// Calculate Objects - Loops over all triangle in every mesh.
			foreach (Mesh M in Objects)
			{
				// Check if the mesh has physics.
				if (M.HasPhysics)
				{
					// Apply physics.
					M.Step(Gravity, 1.0f);
				}

				// Create a rotation matrix for the mesh - Separate from camera rotation.
				Matrix4x4 Rotation = M.GetRotationMatrix();

				foreach (Triangle T in M.Triangles)
				{
					Triangle Temp = T.Transform(Rotation); // Apply object rotation - Separate from camera rotation.
					Temp = Temp.Translate(M.Position); // Apply object translation - The position it is in 3D.
					Temp = Temp.Transform(CameraQ); // Apply camera rotation - Rotates the entire world as one mesh.
					Temp = Temp.Translate(Camera.Position); // Apply camera position - Adjusts the world as one mesh.
					Temp = Temp.Translate(Translator); // Apply perspective translation - Applies a 3D effect.

					// Check if the triangle doesn't need to be drawn.
					if (Temp.GetNormal() < 0)
					{
						// Moves everything to center - Most 3D renderers do this.
						Temp = Temp.Center(Width, Height);

						// Normalize lighting & apply ambiance.
						Temp.Color = Color.Normalize(Temp.Color);
						Temp.Color *= Camera.Ambient;

						// Rasterize the triangle.
						DrawFilledTriangle(Temp);
					}
				}
			}
		}

		#endregion

		#region Fields

		public List<Light> Lights;
		public List<Mesh> Objects;
		public Color SkyColor;
		public Camera Camera;
		public float Gravity;
		public float Zoom;

		#endregion
	}
}