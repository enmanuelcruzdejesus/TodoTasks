using System;
using TodoTasks.Models;
using Xamarin.Forms;

namespace TodoTasks.Views
{
    public class CheckDataTemplateSelector: DataTemplateSelector
    {
        private DataTemplate checkMarkTemplate;
        private App app = (App)App.Current;

        public CheckDataTemplateSelector()
        {
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var task = (Tasks)item;
            if (task.completed)
            {
                checkMarkTemplate = new DataTemplate(typeof(CheckMarkViewCell));
                checkMarkTemplate.SetBinding(CheckMarkViewCell.TitleTextProperty, "completed");
                return checkMarkTemplate;
            }

            var defaultTemplate = new DataTemplate(() =>
            {
                StackLayout stackLayout = new StackLayout();
                stackLayout.Padding = new Thickness(15, 0, 0, 0);
                stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                stackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                var label = new Label()
                {
                    Style = (Style)app.Resources["titleLabelStyle"]
                };
                label.SetBinding(Label.TextProperty, "completed");
                stackLayout.Children.Add(label);
                return new ViewCell() { View = stackLayout };

            });
            return defaultTemplate;


        }
    }
}
}
