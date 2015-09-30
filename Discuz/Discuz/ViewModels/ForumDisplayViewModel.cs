using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Discuz.Api;
using Discuz.Api.Entities;
using Discuz.Api.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ForumDisplayViewModel : Screen {

        private int OldID = 0;

        public int ID {
            get;
            set;
        }

        public BindableCollection<ThreadSummaryViewModel> Datas {
            get;
            set;
        }

        private INavigationService NS = null;

        public ForumDisplayViewModel(INavigationService ns) {
            this.NS = ns;
        }

        protected override void OnActivate() {
            base.OnActivate();

            if (this.OldID != this.ID)
                this.LoadData();
        }

        private async void LoadData() {
            var method = new ForumDisplay() {
                ForumID = this.ID
            };
            var datas = await ApiClient.Execute(method);
            var vms = datas.Select(t => new ThreadSummaryViewModel(t, this.NS));
            this.Datas = new BindableCollection<ThreadSummaryViewModel>(vms);

            this.NotifyOfPropertyChange(() => this.Datas);
            this.OldID = this.ID;
        }
    }
}
