using Caliburn.Micro;
using Discuz.Api;
using Discuz.Api.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ViewThreadViewModel : Screen {

        private int OldID = 0;

        public int ThreadID {
            get;
            set;
        }


        public BindableCollection<PostDetailViewModel> Datas {
            get;
            set;
        }

        protected override void OnActivate() {
            base.OnActivate();

            if (this.OldID != this.ThreadID)
                this.LoadData();
        }

        private async void LoadData() {
            var method = new ViewThread() {
                ThreadID = this.ThreadID
            };
            var datas = await ApiClient.Execute(method);
            var vms = datas.Select(d => new PostDetailViewModel(d));
            this.Datas = new BindableCollection<PostDetailViewModel>(vms);
            this.NotifyOfPropertyChange(() => this.Datas);
            this.OldID = this.ThreadID;
        }
    }
}
