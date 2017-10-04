using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InterestHelper
{
    public partial class MainPage : ContentPage
    {
        private Label roborText;
        public MainPage()
        {
            InitializeComponent();
            var button = new Button()
            {
                Text = "Push",
            };
            button.Clicked += OnButtonClicked;
            
            roborText = new Label();
            Content = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {button, roborText}
            };
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            
        }
    }
}
