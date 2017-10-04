using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestHelper.IDataAccessLayer;
using Xamarin.Forms;

namespace InterestHelper
{
    public partial class MainPage : ContentPage
    {
        private readonly Label _roborText;

        public MainPage()
        {
            InitializeComponent();
            var button = new Button()
            {
                Text = "Push",
            };
            button.Clicked += OnButtonClicked;
            
            _roborText = new Label();
            Content = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {button, _roborText}
            };
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var provider = InterestHelperIoc.Resolve<IInputDataProvider>();
            var inputData = await provider.GetRawDataAsync(DateTime.Now.AddDays(-7), DateTime.Now);

            _roborText.Text = inputData.First().Item2;
            var random = new Random();
            _roborText.TextColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
        }
    }
}
