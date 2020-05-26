using System;
using System.Collections.Generic;
using TodoTasks.ViewModels;
using Xamarin.Forms;

namespace TodoTasks.Views
{
    public partial class TaskDetailPage : ContentPage
    {
        TaskDetailPageViewModel _vm;
        public TaskDetailPage(TaskDetailPageViewModel viewModel )
        {
            _vm = viewModel;
            InitializeComponent();
            this.BindingContext = viewModel;
        }


    }
}
