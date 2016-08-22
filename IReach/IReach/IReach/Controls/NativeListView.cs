using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReach.Models;
using Xamarin.Forms;

namespace IReach
{
    public class NativeListView : ListView
    {
        public static readonly BindableProperty ItemsProperty =
           BindableProperty.Create ( "Items", typeof ( IEnumerable<food> ), typeof ( NativeListView ), new List<food> ( ) );

        public IEnumerable<food> Items
        {
            get { return ( IEnumerable<food> )GetValue ( ItemsProperty ); }
            set { SetValue ( ItemsProperty, value ); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public void NotifyItemSelected ( object item )
        {
            ItemSelected?.Invoke ( this, new SelectedItemChangedEventArgs ( item ) );
        }
    }
}
