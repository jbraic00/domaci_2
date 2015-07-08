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
using Zadatak2.Controls;

namespace Zadatak1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.addLeftButton.Click += addLeftButton_Click;
            this.addRightButton.Click += addRightButton_Click;

            for (var i = 0; i < this.UserContainer.Children.Count; i++)
            {
                var element = this.UserContainer.Children[i];
                if (element is User)
                {
                    var user = (User)element;
                    user.Delete += user_Delete;
                }
            }

            for (var i = 0; i < this.PostContainer.Children.Count; i++)
            {
                var element = this.PostContainer.Children[i];
                if (element is Post)
                {
                    var post = (Post)element;
                    post.Delete += post_Delete;
                }
            }
        }

        void post_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post))
            {
                return;
            }

            var post = sender as Post;

            var indexOfElement = this.PostContainer.Children.IndexOf(post);

            if (indexOfElement == -1)
            {
                return;
            }

            this.PostContainer.Children.RemoveAt(indexOfElement);
        }

        void user_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User))
            {
                return;
            }

            var user = sender as User;

            var indexOfElement = this.UserContainer.Children.IndexOf(user);

            if (indexOfElement == -1)
            {
                return;
            }

            this.UserContainer.Children.RemoveAt(indexOfElement);
        }

        void addRightButton_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post();
            newPost.Width = 375;
            newPost.Height = 100;
            newPost.Margin = new Thickness(15);
            newPost.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam in viverra libero. Nulla mattis massa quis tellus facilisis, vitae faucibus ex lobortis. Donec cursus massa metus, in imperdiet orci condimentum id. Vivamus ac nibh eget risus vulputate suscipit. Donec lorem turpis, vulputate pharetra sagittis vel, luctus nec metus.";
            newPost.Delete += post_Delete;

            this.PostContainer.Children.Add(newPost);
        }

        void addLeftButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            newUser.Width = 90;
            newUser.Height = 90;
            newUser.Margin = new Thickness(15);
            newUser.Title = "Friend";
            newUser.Delete += user_Delete;

            this.UserContainer.Children.Add(newUser);
        }
    }
}
