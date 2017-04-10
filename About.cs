// <copyright file="About.cs" company="None">
//     MIT License (MIT). All rights reserved
// </copyright>
// <author>Christoph Gattnar</author>
// <summary>This is the About class.</summary>

namespace BlueDot
{
    public class About : AboutControlViewModel
    {
        /// <summary>
        /// Shows About box.
        /// </summary>
        public void Show()
        {
            BlueDot.AboutControlView about = new BlueDot.AboutControlView();
            AboutControlViewModel vm = (AboutControlViewModel)about.FindResource("ViewModel");
            vm.AdditionalNotes = this.AdditionalNotes;
            vm.ApplicationLogo = this.ApplicationLogo;
            vm.Copyright = this.Copyright;
            vm.Description = this.Description;
            vm.HyperlinkText = this.HyperlinkText;
            vm.Publisher = this.Publisher;
            vm.PublisherLogo = this.PublisherLogo;
            vm.Title = this.Title;
            vm.Version = this.Version;

            vm.Window.Content = about;
            vm.Window.Show();
        }
    }
}
