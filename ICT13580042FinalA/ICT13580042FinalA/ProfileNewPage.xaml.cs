using ICT13580042FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580042FinalA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileNewPage : ContentPage
    {
        Profile profile;

        public ProfileNewPage(Profile profile = null)
        {
            InitializeComponent();

            this.profile = profile;

            titleLable.Text = profile == null ? "เพิ่มสินค้าใหม่" : "แก้ไขข้อมูลสินค้า";

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            sexPicker.Items.Add("ชาย");
            sexPicker.Items.Add("หญิง");

            statusPicker.Items.Add("โสด");
            statusPicker.Items.Add("แต่งงานแล้ว");
            statusPicker.Items.Add("ม่าย");

            if (profile != null)
            {
                nameEntry.Text = profile.Name;
                surnameEntry.Text = profile.Surname;
                oldEntry.Text = profile.Old.ToString();
                sexPicker.SelectedItem = profile.Sex;
                typeEditor.Text = profile.Type;
                telEntry.Text = profile.Tel.ToString();
                emailEditor.Text = profile.Email;
                addressEditor.Text = profile.Address;
                statusPicker.SelectedItem = profile.Status;
                boyEntry.Text = profile.Boy.ToString();
                salaryEntry.Text = profile.Salary.ToString();

            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (profile == null)
                {
                    profile = new Profile();
                    profile.Name = nameEntry.Text;
                    profile.Surname = surnameEntry.Text;
                    profile.Old = decimal.Parse(oldEntry.Text);
                    profile.Sex = sexPicker.SelectedItem.ToString();
                    profile.Type = typeEditor.Text;
                    profile.Tel = decimal.Parse(telEntry.Text);
                    profile.Email = emailEditor.Text;
                    profile.Address = addressEditor.Text;
                    profile.Status = statusPicker.SelectedItem.ToString();
                    profile.Boy = decimal.Parse(boyEntry.Text);
                    profile.Salary = decimal.Parse(salaryEntry.Text);
                    var id = App.DbHelper.AddProfile(profile);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");
                }
                else
                {
                    profile.Name = nameEntry.Text;
                    profile.Surname = surnameEntry.Text;
                    profile.Old = decimal.Parse(oldEntry.Text);
                    profile.Sex = sexPicker.SelectedItem.ToString();
                    profile.Type = typeEditor.Text;
                    profile.Tel = decimal.Parse(telEntry.Text);
                    profile.Email = emailEditor.Text;
                    profile.Address = addressEditor.Text;
                    profile.Status = statusPicker.SelectedItem.ToString();
                    profile.Boy = decimal.Parse(boyEntry.Text);
                    profile.Salary = decimal.Parse(salaryEntry.Text);
                    var id = App.DbHelper.AddProfile(profile);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย", "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}