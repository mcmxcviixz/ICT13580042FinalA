using ICT13580042FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580042FinalA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;

        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            profileListView.ItemsSource = App.DbHelper.GetProfiles();
        }

        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProfileNewPage());
        }

        void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var profile = button.CommandParameter as Profile;
            Navigation.PushModalAsync(new ProfileNewPage(profile));
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Profile;
                App.DbHelper.DeleteProfile(product);

                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
                LoadData();
            }
        }
    }
}
