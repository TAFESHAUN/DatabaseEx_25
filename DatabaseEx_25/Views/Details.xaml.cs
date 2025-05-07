using DatabaseEx_25.Data;

namespace DatabaseEx_25.Views;

public partial class Details : ContentPage
{
    private Repository _repo;
    private Products productD;
    private Products _productDetails;

    public Details(Products productSend, Repository repo)
    {
        InitializeComponent();
        _repo = repo;

        productD = productSend;
        _productDetails = productSend;

        DetailsId.Text = productD.Id.ToString(); //int to string
        DetailsProductName.Text = productD.Product;
        DetailsCode.Text = productD.Code;
        DetailsPrice.Text = productD.Price.ToString();//int to string
    }

    //Update
    async void Button_Clicked(object sender, EventArgs e)
    {
        _productDetails.Product = NameUpdate.Text;
        _productDetails.Price = Convert.ToInt32(PriceUpdate.Text);//CHANGE TO DEC

        try
        {
            _repo.UpdateProduct(_productDetails);
            await Navigation.PushAsync(new MainPage());//PROPER MVVM
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //Delete
    async void Button_Clicked_1(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("DELETE PRODUCT", "Are you sure you want to delete?", "Yes", "No");
        if (answer == true)
        {
            try
            {
                _repo.DeleteProduct(_productDetails);
                await Navigation.PushAsync(new MainPage());//POP -> Refreash ALL DATA on mainpage.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            await DisplayAlert("Resolved", "You did not delete", "Ok");
            //await Navigation.PushAsync(new MainPage());
            //await Navigation.PopAsync();
        }
    }
}