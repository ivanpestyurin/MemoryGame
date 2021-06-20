using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            var action = await DisplayActionSheet("Choose pics", "Cancel", null, "fish", "cat");
            if (action.Equals("Cancel"))
            {
                btn.IsEnabled = true;
            }
            else
            {
                await Navigation.PushModalAsync(new MemoryCards(action));
                btn.IsEnabled = true;
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}