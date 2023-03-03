using System.Numerics;

namespace PrismGraphics.Rasterizer
{
    /// <summary>
    /// The <see cref="Light"/> class, used to represent a light's type, position, rotation, and color.
    /// </summary>
    public class Light
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Light"/> class.
        /// </summary>
        /// <param name="Position">The position of the light source.</param>
        /// <param name="Rotation">The rotation of the light source.</param>
        /// <param name="Color">The color of the light source.</param>
        /// <param name="Type">The kind of light to render.</param>
        public Light(Vector3 Position, Vector3 Rotation, LightTypes Type, Color Color)
        {
            this.Position = Position;
            this.Rotation = Rotation;
            this.Color = Color;
            this.Type = Type;
        }

        #region Fields

        public Vector3 Position;
        public Vector3 Rotation;
        public LightTypes Type;
        public Color Color;

		#endregion
	}
}