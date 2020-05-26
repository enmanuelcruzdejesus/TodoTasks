using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoTasks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckMarkViewCell : ViewCell
    {
        public static BindableProperty TitleTextProperty = BindableProperty.Create
                                                                           (nameof(TitleText),
                                                                            typeof(string),
                                                                            typeof(CheckMarkViewCell),
                                                                            string.Empty,
                                                                            BindingMode.OneWay);

        public string TitleText
        {
            get
            {
                return (string)GetValue(TitleTextProperty);
            }
            set
            {
                SetValue(TitleTextProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleTextProperty.PropertyName)
            {
                this.lblTitle.Text = TitleText;
            }
        }

        public CheckMarkViewCell()
        {
            InitializeComponent();
        }
    }
}
