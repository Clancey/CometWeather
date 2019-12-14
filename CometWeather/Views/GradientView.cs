using System;
using System.Drawing;
using Comet;
using Comet.Skia;
using SkiaSharp;
using Color = Comet.Color;

namespace CometWeather.Views
{
    public class GradientView : AbstractControlDelegate
    {
        public GradientView(Binding<Color> startColor, Binding<Color> endColor)
        {
            StartColor = startColor;
            EndColor = endColor;
            Invalidate();
        }
        public GradientView(
           Func<Color> startColor, Func<Color> endColor) : this((Binding<Color>)startColor, (Binding<Color>)endColor)
        {

        }

        Binding<Color> startColor;
        public Binding<Color> StartColor {
            get => startColor;
            set => this.SetBindingValue(ref startColor, value);
        }

        Binding<Color> endColor;
        public Binding<Color> EndColor {
            get => endColor;
            set => this.SetBindingValue(ref endColor, value);
        }

        public override void Draw(SKCanvas canvas, RectangleF dirtyRect)
        {
            canvas.Clear();
            var skColors = new[]
            {
                StartColor.CurrentValue.ToSKColor(),
                EndColor.CurrentValue.ToSKColor(),
            };
            using (SKPaint paint = new SKPaint())
            {
                // Create gradient for background
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(0, 0),
                                    new SKPoint(dirtyRect.Width, dirtyRect.Height),
                                    skColors,
                                    null,
                                    SKShaderTileMode.Clamp);

                canvas.DrawRect(dirtyRect.ToSKRect(), paint);
            }
        }
        public override void ViewPropertyChanged(string property, object value)
        {
            if (property == nameof(StartColor) || property == nameof(EndColor))
            {
                Invalidate();
            }
            base.ViewPropertyChanged(property, value);
        }
    }
}
