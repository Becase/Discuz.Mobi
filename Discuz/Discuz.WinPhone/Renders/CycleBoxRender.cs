using Discuz.Controls;
using Discuz.WinPhone.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(CycleBox), typeof(CycleBoxRender))]
namespace Discuz.WinPhone.Renders {
    public class CycleBoxRender : ViewRenderer<CycleBox, System.Windows.Controls.Border> {

        public CycleBoxRender() {
            //AutoPack will cause a exception : MS.Internal.XcpImports.CheckHResult(UInt32 hr)
            //I don't know what's mean,
            //this.AutoPackage = false;//
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CycleBox> e) {
            base.OnElementChanged(e);

            this.SetNativeControl(new System.Windows.Controls.Border());

            //this.PackChildren();
            this.UpdateControl();
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            this.Element.HorizontalOptions = LayoutOptions.Center;
            this.Element.VerticalOptions = LayoutOptions.Center;

            if (e.PropertyName.Equals(CycleBox.RadiusProperty.PropertyName, StringComparison.OrdinalIgnoreCase)) {
                this.UpdateControl();
            }
        }

        protected override void UpdateBackgroundColor() {
            //base.UpdateBackgroundColor();
            if (Control != null) {
                Control.Background = this.Element.BackgroundColor.ToBrush();
            }
        }

        //private void PackChildren() {
        //    if (this.Element.Content == null)
        //        return;

        //    if (this.Element.Content.GetRenderer() == null)
        //        this.Element.Content.SetRenderer(RendererFactory.GetRenderer(this.Element.Content));

        //    var render = this.Element.Content.GetRenderer() as UIElement;
        //    this.Control.Child = render;
        //}

        private void UpdateControl() {
            var w = this.Element.Radius * 2;
            this.Control.Height = w;
            this.Control.Width = w;
            this.Control.MinHeight = w;
            this.Control.MinWidth = w;
            this.Element.WidthRequest = w;
            this.Element.HeightRequest = w;

            this.Control.CornerRadius = new CornerRadius(this.Element.Radius);
            var render = this.Element.Content.GetRenderer() as UIElement;
            var min = this.Element.Radius;
            if (min > 0) {
                render.Clip = new EllipseGeometry {
                    Center = new System.Windows.Point(min, min),
                    RadiusX = min,
                    RadiusY = min
                };

            }
        }
    }
}
