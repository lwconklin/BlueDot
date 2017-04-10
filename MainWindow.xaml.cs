// <copyright file="MainWindow.xaml.cs" company="AirOsprey">
//     MIT License (MIT). All rights reserved
// </copyright>
// <author>Larry Conklin</author>
// <summary>This is the MainWindow class.</summary>
using System;
using System.Timers;
using System.Windows;
using System.Windows.Forms;

namespace BlueDot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer blink;
        private static System.Windows.Forms.NotifyIcon ni;

        public MainWindow()
        {
            InitializeComponent();
            ni = new System.Windows.Forms.NotifyIcon();

            ni.Visible = true;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
         }

        /// <summary>
        /// Key Press.
        /// </summary>
        public static void KeyPress()
        {
            SendKeys.SendWait("{F15}");
            ni.Visible = true;
        }

        /// <summary>
        /// Set Blink Timing.
        /// </summary>
        public static void SetBlink()
        {
            blink = new System.Timers.Timer(2000); // Two second interval.
            blink.Elapsed += BlinkEvent;
            blink.AutoReset = true;
            blink.Enabled = true;
        }

        /// <summary>
        /// State Changed.
        /// </summary>
        /// <param name="e">Event Args.</param>
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }

            base.OnStateChanged(e);
        }

        /// <summary>
        /// State Changed.
        /// </summary>
        /// <param name="source">System object.</param>
        /// <param name="e">Elapsed event args.</param>
        private static void BlinkEvent(Object source, ElapsedEventArgs e)
        {
            ni.Visible = false;
            KeyPress();
        }

        /// <summary>
        /// Exit program via menu option.
        /// </summary>
        /// <param name="sender">Object source.</param>
        /// <param name="e">Routed event args.</param>
        private void mnuNew_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// About window box via menu option.
        /// </summary>
        /// <param name="sender">Object source.</param>
        /// <param name="e">Routed event args.</param>
        private void MenuItem_About(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.IsSemanticVersioning = true;
            about.HyperlinkText = "https://github.com/lwconklin";
            about.Show();
            
        }

        /// <summary>
        /// Start program button.
        /// </summary>
        /// <param name="sender">Object source.</param>
        /// <param name="e">Routed event args.</param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            SetBlink();
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Stop program button.
        /// </summary>
        /// <param name="sender">Object source.</param>
        /// <param name="e">Routed event args.</param>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            blink.Stop();
            blink.Close();
            blink.Dispose();
            this.WindowState = WindowState.Minimized;
        }
    }
}
