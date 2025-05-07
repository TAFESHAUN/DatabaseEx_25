using DatabaseEx_25.Data;
using System.Collections.ObjectModel;
using DatabaseEx_25.Views;


namespace DatabaseEx_25
{
    public partial class MainPage : ContentPage
    {
        //Set Up repo for SSMS local host DB
        private Repository _repo;

        ObservableCollection<Products> productL = new ObservableCollection<Products>();
        public ObservableCollection<Products> ProductL { get { return productL; } }

        public MainPage()
        {

            InitializeComponent();

            //Load DB
            var repo = new Repository();
            var productList = repo.GetProduct();
            _repo = repo;

            ProductView.ItemsSource = productL;

            foreach (var product in productList)
            {
                productL.Add(product);
            }

        }

        async void ProductView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = e.SelectedItem as Products;
            await Navigation.PushAsync(new Details(product, _repo));
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insert(_repo));
        }
    }

}
