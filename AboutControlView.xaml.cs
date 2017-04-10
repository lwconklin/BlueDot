// <copyright file="AboutControlView.xaml.cs" company="None">
//     MIT License (MIT). All rights reserved
// </copyright>
// <author>Christoph Gattnar</author>
// <summary>This is the AboutControlView class.</summary>
namespace BlueDot
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for AboutControlView.xaml
    /// </summary>
    public partial class AboutControlView : UserControl
    {
        public AboutControlView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hyper link in about box.
        /// </summary>
        /// <param name="sender">Object System.</param>
        /// <param name="e">Request Navigate Event Args.</param>
        private void Link_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// User control of left button down on mouse.
        /// </summary>
        /// <param name="sender">Object System.</param>
        /// <param name="eventArgs">Request Navigate Event Args.</param>
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.ChangedButton == MouseButton.Left)
            {
                Window parent = Parent as Window;
                if (parent != null)
                {
                    parent.DragMove();
                }
            }
        }
    }
}
