using System;
using System.Collections.Generic;
using TodoTasks.Models;
using TodoTasks.ViewModels;
using Xamarin.Forms;

namespace TodoTasks.Views
{
    public partial class TaskPage : ContentPage
    {

        TaskPageViewModel _vm;


        public TaskPage()
        {
            _vm = new TaskPageViewModel();
            InitializeComponent();
            this.BindingContext = _vm;
            this.taskListView.ItemTapped += async (s, e) =>
             {
                 var item = (Tasks)e.Item;
                 var page = (NavigationPage)App.Current.MainPage;
                 await page.Navigation.PushAsync(new TaskDetailPage(new TaskDetailPageViewModel(item, false)));

             };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.taskListView.ItemsSource = _vm.Tasks;
        }
    }
}
