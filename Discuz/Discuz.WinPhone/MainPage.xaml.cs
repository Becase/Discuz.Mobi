using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Caliburn.Micro;

namespace Discuz.WinPhone {
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage {
        public MainPage() {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new Discuz.App(IoC.Get<PhoneContainer>()));

            //菜单栏最小化
            this.ApplicationBar.Opacity = 0.75;
            this.ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }
    }
}
