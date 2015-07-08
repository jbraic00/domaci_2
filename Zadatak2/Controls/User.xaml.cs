using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadatak2.Controls
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
        (
          "Title",
          typeof(string),
          typeof(User),
          new UIPropertyMetadata("Title")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
            "Delete", 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) 
        );

        public event RoutedEventHandler Delete 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.DeleteButton.MouseDown += DeleteButton_MouseDown;
        }

        void DeleteButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }
    }
}
