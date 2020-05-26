using System;
using System.Linq;
using System.Windows.Input;
using TodoTasks.Models;
using Xamarin.Forms;

namespace TodoTasks.ViewModels
{
    public class TaskDetailPageViewModel
    {
        bool _isNewRecord;
        private Tasks _task;
        ICommand _saveCommand;
        ICommand _deleteCommand;
        App app = (App)App.Current;


        public Tasks Task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
            }
        }




        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new Command(new Action(async () =>
                {
                    
                    var db = app.Db;

                    _task.created = DateTime.Now;
                    if (_isNewRecord)
                    {

                        var id = app.Db.Tasks.GetAll().Count() + 1;
                        _task.taskid = id;
                        

                        app.Db.Tasks.Insert(_task);

                    }
                    else
                    {
                        app.Db.Tasks.Update(_task);
                    }


                    App.ToastDialogAlert("the task was created sucessfully", 2000);


                    var page = (NavigationPage)App.Current.MainPage;
                    await page.PopAsync();


                }));
                return _saveCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new Command(new Action(async () =>
                {
                    var db = app.Db;
                    db.Tasks.Delete(_task);

                    var page = (NavigationPage)App.Current.MainPage;
                    await page.PopAsync();




                }));

                return _deleteCommand;
            }
        }



        public TaskDetailPageViewModel(Tasks task, bool isNewRecord)
        {
            _task = task;
            _isNewRecord = isNewRecord;
        }
    }
}
