using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TodoTasks.Models;
using TodoTasks.Views;
using Xamarin.Forms;

namespace TodoTasks.ViewModels
{
    public class TaskPageViewModel
    {
        ObservableCollection<Tasks> _tasks;

        ICommand _addTaskCommand;

        public ObservableCollection<Tasks> Tasks
        {
            get
            {
                var app = (App)App.Current;
                var data = app.Db.Tasks.GetAll();
                return new ObservableCollection<Tasks>(data);
            }
        }



        public ICommand AddTaskCommand
        {
            get
            {
                _addTaskCommand = _addTaskCommand ?? new Command(new Action(async ()=>
                {
                    var newTask = new Tasks();
                    newTask.created = DateTime.Now;
                    var page = (NavigationPage)App.Current.MainPage;
                    await page.Navigation.PushAsync(new TaskDetailPage(new TaskDetailPageViewModel(newTask, true)));
                }));
                return _addTaskCommand;
            }
        }


        public TaskPageViewModel()
        {
            var app = (App)App.Current;
            var data = app.Db.Tasks.GetAll();
            _tasks = new ObservableCollection<Tasks>(data);

        }

        
    }
}
