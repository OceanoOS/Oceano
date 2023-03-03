using System.Collections.Generic;

namespace PrismGraphics.Fonts
{
	/// <summary>
	/// The glyph class, used for caching font glyphs.
	/// See: https://github.com/Project-Prism/Prism-OS/tree/main/PrismGraphics/Font/README.md#Glyphs
	/// </summary>
	public class Glyph
	{
		/// <summary>
		/// Creates a new instance of the <see cref="Glyph"/> class.
 		/// </summary>
		/// <param name="Width">The width of the glyph.</param>
		/// <param name="Height">The height of the glyph.</param>
		public Glyph(ushort Width, ushort Height)
		{
			this.Height = Height;
			this.Width = Width;
			Points = new();
		}

		#region Properties

		/// <summary>
		/// A basic check to see if there are any pixels that need to be drawn.
		/// </summary>
		public bool IsEmpty => Points.Count == 0;

		#endregion

		#region Fields

		public List<(int X, int Y)> Points;
		public ushort Height;
		public ushort Width;

		#endregion
	}
}