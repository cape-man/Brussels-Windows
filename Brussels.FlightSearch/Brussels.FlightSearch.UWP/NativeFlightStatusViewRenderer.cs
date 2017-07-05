using Brussels.FlightSearch;
using Brussels.FlightSearch.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(FlightStatusView), typeof(NativeFlightStatusViewRenderer))]
namespace Brussels.FlightSearch.UWP
{
    public class NativeFlightStatusViewRenderer : ViewRenderer<FlightStatusView, Grid>
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Flight" && grid != null && uWPflightStatusView != null)
            {
                uWPflightStatusView.Flight = ((FlightStatusView)sender).Flight;
            }

        }
        Grid grid;
        UWPFlightStatusView uWPflightStatusView;
        protected override void OnElementChanged(ElementChangedEventArgs<FlightStatusView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                
            }

            if (e.NewElement != null)
            {
                grid = new Grid();
                grid.BorderThickness = new Windows.UI.Xaml.Thickness(5);

                uWPflightStatusView = new UWPFlightStatusView();                
                grid.Children.Add(uWPflightStatusView);
                               
                SetNativeControl(grid);
            }
            if (e.OldElement != null)
            {

            }
        }
        
    }
}
