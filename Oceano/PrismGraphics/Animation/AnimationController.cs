using System;
using System.Threading;

namespace PrismGraphics.Animation
{
	/// <summary>
	/// The <see cref="AnimationController"/> class, used to add basic ease animations or transitions to anything.
	/// See: <seealso href="https://www.febucci.com/2018/08/easing-functions/"/>
	/// </summary>
	public class AnimationController
	{
		/// <summary>
		/// Creates a new instance of the <see cref="AnimationController"/> class.
		/// </summary>
		/// <param name="Source">The starting value.</param>
		/// <param name="Target">The value to end at.</param>
		/// <param name="Duration">The duration to play the animation over.</param>
		/// <param name="Mode">The ease animation mode.</param>
		public AnimationController(float Source, float Target, TimeSpan Duration, AnimationMode Mode)
		{
			// Assign internal data.
			Current = Source;
			this.Source = Source;
			this.Target = Target;
			this.Duration = Duration;
			this.Mode = Mode;

			// Assign the timer.
			Timer = new((object? O) => Next(), null, DelayMS, 0);
		}

		#region Properties

		/// <summary>
		/// A boolean to tell if the animation has finished.
		/// </summary>
		public bool IsFinished => ElapsedTime >= Duration.TotalMilliseconds;

		#endregion

		#region Constants

		/// <summary>
		/// The delay in MS of each update.
		/// </summary>
		public const int DelayMS = 25;

		#endregion

		#region Methods

		private static float BounceOut(float T)
		{
			if (T < (1f / 2.75f))
			{
				return 7.5625f * T * T;
			}
			else if (T < (2f / 2.75f))
			{
				return 7.5625f * (T -= 1.5f / 2.75f) * T + 0.75f;
			}
			else if (T < (2.5f / 2.75f))
			{
				return 7.5625f * (T -= (2.25f / 2.75f)) * T + 0.9375f;
			}
			else
			{
				return 7.5625f * (T -= 2.625f / 2.75f) * T + 0.984375f;
			}
		}

		private static float BounceIn(float T)
		{
			return 1f - BounceOut(1f - T);
		}

		private static float Bounce(float T)
		{
			if (T < 0.5f)
			{
				return BounceIn(T * 2f) * 0.5f;
			}
			else
			{
				return BounceOut(T * 2f - 1f) * 0.5f + 0.5f;
			}
		}

		private static float EaseOut(float T)
		{
			return Flip((float)Math.Pow(Flip(T), 2));
		}

		private static float EaseIn(float T)
		{
			return T * T;
		}

		private static float Ease(float T)
		{
			return Common.Lerp(EaseIn(T), EaseOut(T), T);
		}

		private static float Flip(float X)
		{
			return 1 - X;
		}

		/// <summary>
		/// Internal method, used by the timer to increment the final value.
		/// </summary>
		/// <exception cref="NotImplementedException">Thrown when invalid animation is played.</exception>
		private void Next()
		{
			if (IsFinished)
			{
				return;
			}
			
			// Increased the elapsed time.
			ElapsedTime += DelayMS;

			// Set the output value.
			Current = Mode switch
			{
				AnimationMode.BounceOut => Common.Lerp(Source, Target, BounceOut(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.BounceIn => Common.Lerp(Source, Target, BounceIn(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.Bounce => Common.Lerp(Source, Target, Bounce(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.EaseOut => Common.Lerp(Source, Target, EaseOut(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.EaseIn => Common.Lerp(Source, Target, EaseIn(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.Ease => Common.Lerp(Source, Target, Ease(ElapsedTime / (float)Duration.TotalMilliseconds)),
				AnimationMode.Linear => Common.Lerp(Source, Target, ElapsedTime / (float)Duration.TotalMilliseconds),
				_ => throw new NotImplementedException("That mode isn't implemented!"),
			};
		}

		/// <summary>
		/// Resets the progress and plays the new values if new ones were set.
		/// </summary>
		public void Reset()
		{
			ElapsedTime = 0;
		}

		#endregion

		#region Fields

		/// <summary>
		/// A value marking points in the animation.
		/// </summary>
		public float Current, Source, Target, ElapsedTime;

		/// <summary>
		/// The animation mode to use.
		/// </summary>
		public AnimationMode Mode;

		/// <summary>
		/// The duration in which to play the animation over.
		/// </summary>
		public TimeSpan Duration;

		/// <summary>
		/// Animation timer, used to increment the animation every 50 MS.
		/// </summary>
		public Timer Timer;

		#endregion
	}
}