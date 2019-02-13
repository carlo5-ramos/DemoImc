using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoIMC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculosImcPage : ContentPage
	{
		public CalculosImcPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}