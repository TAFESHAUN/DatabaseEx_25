using DatabaseEx_25.Data;

namespace DatabaseEx_25.Views;

public partial class Insert : ContentPage
{
    private Repository _repo;
    private Products productInsert;
    public Insert(Repository repo)
    {
        InitializeComponent();
        _repo = repo;
        var prod = new Products();
        productInsert = prod;
    }

    //Insert
    async void Button_Clicked(object sender, EventArgs e)
    {
        productInsert.Product = NameInsert.Text;
        productInsert.Price = Convert.ToInt32(PriceInsert.Text);
        productInsert.Code = CodeInsert.Text;

        try
        {
            // Run DB insert on background thread
            int result = await Task.Run(() => _repo.InsertProduct(productInsert));

            if (result > 0)
            {
                await DisplayAlert("Success", "Product inserted.", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Insert failed.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", ex.Message, "OK");
        }
    }

}