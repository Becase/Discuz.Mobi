using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Discuz.Api;
using Discuz.Api.Entities;
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
                .Singleton<ViewThreadViewModel>()
                .PerRequest<LoginViewModel>();

            this.DisplayRootView<ForumIndexView>();

            ApiClient.OnMessage += ApiClient_OnMessage;
        }

        async void ApiClient_OnMessage(object sender, MessageArgs e) {
            Device.BeginInvokeOnMainThread(() => {
                this.DealMessage(e);
            });
        }

        private async void DealMessage(MessageArgs e) {
            switch (e.ErrorType) {
                case ErrorTypes.NoneForumPermission:
                case ErrorTypes.NoneThreadPermission:
                    var nav = await this.MainPage.DisplayAlert("提示", e.Message, "切换账户", "返回上一页");
                    if (nav) {
                        this.Container.GetInstance<INavigationService>()
                            .For<LoginViewModel>()
                            .Navigate();
                    } else {
                        await this.Container.GetInstance<INavigationService>().GoBackAsync();
                    }
                    break;
                default:
                    await this.MainPage.DisplayAlert("提示", e.Message, "OK");
                    break;
            }
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage) {
            this.Container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

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
