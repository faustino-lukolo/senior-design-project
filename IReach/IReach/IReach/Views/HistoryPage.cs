using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace IReach.Views
{
    public class HistoryPage : ContentPage
    {
        public string Heading;
        public HistoryPage ( )
        {
            Title = "Activity and Diet History Page";

            Heading = "This is your History";
            
        }
    }
}
