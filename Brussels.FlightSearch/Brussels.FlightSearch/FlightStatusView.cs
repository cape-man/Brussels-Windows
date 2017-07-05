using Brussels.FlightSearch.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Brussels.FlightSearch
{
    public class FlightStatusView : View
    {
        public static readonly BindableProperty FlightProperty =
            BindableProperty.Create(propertyName: "Flight", returnType: typeof(Flight), declaringType: typeof(FlightStatusView), defaultValue: new Flight(), defaultBindingMode: BindingMode.TwoWay, propertyChanged: handlePropertyChanged);

        private static void handlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var flightStatusView = (FlightStatusView)bindable;
            flightStatusView.Flight = (Flight)newValue;

        }

        public Flight Flight
        {
            get
            {
                return (Flight)GetValue(FlightProperty);
            }
            set
            {
                SetValue(FlightProperty, value);
            }
        }
    }
}
