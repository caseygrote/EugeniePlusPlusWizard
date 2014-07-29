using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;

namespace EugeniePlusPlusWizard
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {



        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void ruledrop_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ColorAnimation animation = new ColorAnimation();
            animation.From = Color.FromArgb(255, 0, 0, 128);
            animation.To = Color.FromArgb(0, 0, 0, 128);
            animation.Duration = new TimeSpan(0, 0, 2);

            RuleAddedPulsar.Foreground = Brushes.Navy;
            PropertyPath colorTargetPath = new PropertyPath("(Label.Foreground).(SolidColorBrush.Color)");
            Storyboard story = new Storyboard();
            Storyboard.SetTarget(animation, RuleAddedPulsar);
            Storyboard.SetTargetProperty(animation, colorTargetPath);
            story.Children.Add(animation);
            story.Begin();
            
        }

        Boolean FirstTask = true;

        private void ClearResults_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            //update count if multiple devices ?
            //ResultBox1.Visibility = Visibility.Hidden;

            TaskA.Visibility = Visibility.Hidden;
            TaskB.Visibility = Visibility.Hidden;
        }

        private void generateResults_PreviewTouchDown(object sender, TouchEventArgs e)
        {

            //Alternates task results
            if (FirstTask)
            {
                TaskA.Visibility = Visibility.Visible;
                TaskB.Visibility = Visibility.Hidden;
                FirstTask = false;
            }
            else
            {
                TaskA.Visibility = Visibility.Hidden;
                TaskB.Visibility = Visibility.Visible;
                FirstTask = true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            rulestxt.Text = rulestxt.Text+ "\n" + b.Content;
            b.Background = Brushes.SlateGray;
        }

        private void button1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            rulestxt.Text = "//miniEugene code";
        }
    }
}