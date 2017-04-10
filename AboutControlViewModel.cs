// <copyright file="AboutControlViewModel.cs" company="None">
//     MIT License (MIT). All rights reserved
// </copyright>
// <author>Christoph Gattnar</author>
// <summary>This is the AboutControlViewModel class.</summary>

namespace BlueDot
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Media;

    public class AboutControlViewModel : INotifyPropertyChanged
    {
        private ImageSource _ApplicationLogo;
        private string _Title;
        private string _Description;
        private string _Version;
        private ImageSource _PublisherLogo;
        private string _Copyright;
        private string _AdditionalNotes;
        private string _HyperlinkText;
        private Uri _Hyperlink;
        private string _Publisher;
        private bool _isSemanticVersioning;

        public AboutControlViewModel()
        {
            Window = new Window();
            Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Window.SizeToContent = SizeToContent.WidthAndHeight;
            Window.ResizeMode = ResizeMode.NoResize;
            Window.WindowStyle = WindowStyle.None;

            Window.ShowInTaskbar = false;
            Window.Title = "About";
            Window.Deactivated += this.Window_Deactivated;

            Assembly assembly = Assembly.GetEntryAssembly();
            this.Version = assembly.GetName().Version.ToString();
            this.Title = assembly.GetName().Name;
            
#if NET35 || NET40
            AssemblyCopyrightAttribute copyright = Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
            AssemblyDescriptionAttribute description = Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
            AssemblyCompanyAttribute company = Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;
#else
            AssemblyCopyrightAttribute copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            AssemblyDescriptionAttribute description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            AssemblyCompanyAttribute company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
#endif
            this.Copyright = copyright.Copyright;
            this.Description = description.Description;
            this.Publisher = company.Company;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Further information about BlueDot... Every 2 seconds BlueDot will send a key press to F15, this is a key most computers do not have.");
            sb.AppendLine("Also BlueDot will keep it's icon visible in the system tray, And it will flash every two seconds to remind you your screen lock is disable.");
            sb.AppendLine("You will need to click on \"System Tray Customize...\" find BlueDot and change icon setting to \"Show Icon and notifications\".");
            sb.AppendLine(string.Empty);
            sb.AppendLine("BlueDot is free and open source.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("FAQ");
            sb.AppendLine("Why id BlueDot an WPF application?");
            sb.AppendLine("No reason I just wanted to create an WPF application.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Can I increase or decrease the time interval?");
            sb.AppendLine("No I hard coded it, maybe later if people ask for it.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("What does the stop button do?");
            sb.AppendLine("Stops the icon from blinking and BlueDot will not send a key press.");
            sb.AppendLine("");
            sb.AppendLine("Do I need to press stop before exiting the program?");
            sb.AppendLine("No I just thought it might be nice if you are going from meeting to meeting you don't have to restart the program.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Does BlueDot take up a lot of cpu resources?");
            sb.AppendLine("No, it should have mininal impact on your machine.");
            this.AdditionalNotes = sb.ToString();
        }

        /// <summary>
        /// Gets or sets the application logo.
        /// </summary>
        /// <value>The application logo.</value>
        public ImageSource ApplicationLogo
        {
            get
            {
                return this._ApplicationLogo;
            }

            set
            {
                if (this._ApplicationLogo != value)
                {
                    this._ApplicationLogo = value;
                    this.OnPropertyChanged("ApplicationLogo");
                }
            }
        }

        /// <summary>
        /// Gets or sets the application title.
        /// </summary>
        /// <value>The application title.</value>
        public string Title
        {
            get
            {
                return this._Title;
            }

            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Gets or sets the application info.
        /// </summary>
        /// <value>The application info.</value>
        public string Description
        {
            get
            {
                return this._Description;
            }

            set
            {
                if (this._Description != value)
                {
                    this._Description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Semantic Versioning is used.
        /// </summary>
        /// <value>Semantic Versioning</value>
        public bool IsSemanticVersioning
        {
            get
            {
                return this._isSemanticVersioning;
            }

            set
            {
                this._isSemanticVersioning = value;
                this.OnPropertyChanged("Version");
            }
        }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>The application version.</value>
        public string Version
        {
            get
            {
                if (this.IsSemanticVersioning)
                {
                    var tmp = this._Version.Split('.');
                    var version = string.Format("{0}.{1}.{2}", tmp[0], tmp[1], tmp[2]);
                    return version;
                }

                return this._Version;
            }

            set
            {
                if (this._Version != value)
                {
                    this._Version = value;
                    this.OnPropertyChanged("Version");
                }
            }
        }

        /// <summary>
        /// Gets or sets the publisher logo.
        /// </summary>
        /// <value>The publisher logo.</value>
        public ImageSource PublisherLogo
        {
            get
            {
                return this._PublisherLogo;
            }

            set
            {
                if (this._PublisherLogo != value)
                {
                    this._PublisherLogo = value;
                    this.OnPropertyChanged("PublisherLogo");
                }
            }
        }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>The publisher.</value>
        public string Publisher
        {
            get
            {
                return this._Publisher;
            }

            set
            {
                if (this._Publisher != value)
                {
                    this._Publisher = value;
                    this.OnPropertyChanged("Publisher");
                }
            }
        }

        /// <summary>
        /// Gets or sets the copyright label.
        /// </summary>
        /// <value>The copyright label.</value>
        public string Copyright
        {
            get
            {
                return this._Copyright;
            }

            set
            {
                if (this._Copyright != value)
                {
                    this._Copyright = value;
                    this.OnPropertyChanged("Copyright");
                }
            }
        }

        /// <summary>
        /// Gets or sets the hyperlink text.
        /// </summary>
        /// <value>The hyperlink text.</value>
        public string HyperlinkText
        {
            get
            {
                return this._HyperlinkText;
            }

            set
            {
                try
                {
                    this.Hyperlink = new Uri(value);
                    this._HyperlinkText = value;
                    this.OnPropertyChanged("HyperlinkText");
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Gets or sets Hyperlink.
        /// </summary>
        /// <value>Hyperlink in about box.</value>
        public Uri Hyperlink
        {
            get
            {
                return this._Hyperlink;
            } 

            set
            {
                if (this._Hyperlink != value)
                {
                    this._Hyperlink = value;
                    this.OnPropertyChanged("Hyperlink");
                }
            }
        }

        /// <summary>
        /// Gets or sets AdditionalNotes.
        /// </summary>
        /// <value>The further info.</value>
        public string AdditionalNotes
        {
            get
            {
                return this._AdditionalNotes;
            }

            set
            {
                if (this._AdditionalNotes != value)
                {
                    this._AdditionalNotes = value;
                    this.OnPropertyChanged("AdditionalNotes");
                }
            }
        }

        /// <summary>
        /// Gets or sets Window.
        /// </summary>
        /// <value>The Window.</value>
        public Window Window
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///Close Window.
        /// </summary>
        /// <param name="sender">Object System.</param>
        /// <param name="e">Event Arguments.</param>
        void Window_Deactivated(object sender, System.EventArgs e)
        {
            Window.Close();
        }

        /// <summary>
        /// Called when a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
