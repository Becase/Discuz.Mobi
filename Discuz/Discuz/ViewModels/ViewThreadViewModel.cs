using Caliburn.Micro;
using Discuz.Api;
using Discuz.Api.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Discuz.ViewModels {
    /// <summary>
    /// 主题详细 （POST LIST)
    /// </summary>
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

        /// <summary>
        /// 是否正在刷新
        /// </summary>
        public bool InRefresh {
            get;
            set;
        }

        /// <summary>
        /// 刷新命令
        /// </summary>
        public ICommand RefreshCmd {
            get;
            set;
        }


        /// <summary>
        /// 加载下一页
        /// </summary>
        public ICommand LoadMore {
            get;
            set;
        }

        /// <summary>
        /// 从1开始
        /// </summary>
        public int Page = 1;

        protected override void OnActivate() {
            base.OnActivate();

            this.RefreshCmd = new Command(() => this.LoadData(true));
            this.LoadMore = new Command(() => this.LoadData(false));

            this.Datas = new BindableCollection<PostDetailViewModel>();

            if (this.OldID != this.ThreadID)
                this.LoadData(true);
        }

        private async void LoadData(bool isRefresh) {
            if (isRefresh)
                this.Page = 1;
            else
                this.Page++;

            this.InRefresh = true;
            this.NotifyOfPropertyChange(() => this.InRefresh);

            var method = new ViewThread() {
                ThreadID = this.ThreadID,
                Page = this.Page
            };
            var datas = await ApiClient.Execute(method);
            var vms = datas.Select(d => new PostDetailViewModel(d));

            if (isRefresh)
                this.Datas = new BindableCollection<PostDetailViewModel>(vms);
            else {
                this.Datas.AddRange(vms);
            }

            this.NotifyOfPropertyChange(() => this.Datas);
            this.OldID = this.ThreadID;

            this.InRefresh = false;
            this.NotifyOfPropertyChange(() => this.InRefresh);
        }
    }
}
