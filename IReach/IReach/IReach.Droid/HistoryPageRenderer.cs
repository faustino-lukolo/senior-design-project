using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IReach.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Com.Squareup.Picasso; 

[assembly: ExportRenderer ( typeof ( IReach.Views.HistoryPage ), typeof ( IReach.Droid.HistoryPageRenderer ) )]
namespace IReach.Droid
{
    public class HistoryPageRenderer : PageRenderer
    {
        Android.Views.View view;
        Context context;

        protected override void OnElementChanged ( ElementChangedEventArgs<Page> e )
        {
            base.OnElementChanged ( e );

            var page = e.NewElement as HistoryPage;

            context = this.Context;
            var activity = context as Activity;

            var historyPageLayout = activity.LayoutInflater.Inflate ( Resource.Layout.HistoryPage, this, false );
            view = historyPageLayout;

            var label = view.FindViewById<TextView> ( Resource.Id.largeTextView );
            label.Text = page.Heading;

            var imageView = view.FindViewById<ImageView> ( Resource.Id.imageView );

            Picasso.With ( context )
                .Load ( "http://i.imgur.com/DvpvklR.jpg" )
                .Into ( imageView );

            AddView ( view );

        }

        protected override void OnLayout ( bool changed, int l, int t, int r, int b )
        {
            base.OnLayout ( changed, l, t, r, b );
            var msw = MeasureSpec.MakeMeasureSpec ( r - l, MeasureSpecMode.Exactly );
            var msh = MeasureSpec.MakeMeasureSpec ( b - t, MeasureSpecMode.Exactly );
            view.Measure ( msw, msh );
            view.Layout ( 0, 0, r - l, b - t );
        }
    }
}