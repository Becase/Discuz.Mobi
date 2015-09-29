using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Discuz.ViewModels;
using Discuz.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Discuz {

    public partial class App : FormsApplication {

        private SimpleContainer Container = null;

        public App(SimpleContainer container) {
            this.InitializeComponent();

            this.Container = container;

            this.Container
                .Singleton<ForumIndexViewModel>()
                .Singleton<ForumDisplayViewModel>()
                .Singleton<ViewThreadViewModel>();

            this.DisplayRootView<ForumIndexView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage) {
            this.Container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        //private void InitializeComponent() {
        //    this.LoadFromXaml(typeof(App));
        //}

        protected override void OnResume() {
            base.OnResume();
        }

        protected override void OnSleep() {
            base.OnSleep();
        }


        protected override void OnStart() {
            base.OnStart();
        }
    }
}
