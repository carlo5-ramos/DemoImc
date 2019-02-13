using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace DemoIMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : Xamarin.Forms.TabbedPage
    {
        public MenuPage ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}