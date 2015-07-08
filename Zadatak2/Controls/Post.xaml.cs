using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
          "Text",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("Text")
        );
        

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
            "Delete", 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) 
        );

        public event RoutedEventHandler Delete  
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void PostControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DeleteButton.MouseDown += DeleteButton_MouseDown;
        }

        void DeleteButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }
    }
}
