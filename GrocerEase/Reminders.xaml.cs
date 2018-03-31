using System;
using System.Collections.Generic;
using Xamrin.Forms.Xaml;
using Xamarin.Forms;

public struct Reminder
{
    public int ID { get; set; }
    public string date { get; set; }
    public bool recurring { get; set; }
    public string itemName { get; set; }
};


namespace GrocerEase
{
    public partial class Reminders : ContentPage
    {
        public Reminders()
        {
            InitializeComponent();
            int reminderCount = 0;
            addButton.Clicked += addButton_Clicked(reminderCount);
        }
    }
    addButton_Clicked(object sender, EventArgs e, int reminderCount)
    {
        
    } 
}
