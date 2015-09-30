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
using System.Windows.Input;
using Xamarin.Forms;

namespace Discuz.ViewModels {
    /// <summary>
    /// 版块主题列表
    /// </summary>
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

        private INavigationService NS = null;

        public ForumDisplayViewModel(INavigationService ns) {
            this.NS = ns;

            this.Datas = new BindableCollection<ThreadSummaryViewModel>();
            this.RefreshCmd = new Command(() => this.LoadData(true));
            this.LoadMore = new Command(() => this.LoadData(false));
        }

        protected override void OnActivate() {
            base.OnActivate();

            if (this.OldID != this.ID)
                this.LoadData(true);
        }

        private async void LoadData(bool isRefresh) {
            if (isRefresh)
                this.Page = 1;
            else
                this.Page++;

            this.InRefresh = true;
            this.NotifyOfPropertyChange(() => this.InRefresh);

            var method = new ForumDisplay() {
                ForumID = this.ID,
                Page = this.Page
            };
            var datas = await ApiClient.Execute(method);
            var vms = datas.Select(t => new ThreadSummaryViewModel(t, this.NS));

            if (isRefresh)
                this.Datas = new BindableCollection<ThreadSummaryViewModel>(vms);
            else {
                this.Datas.AddRange(vms);
            }
            this.NotifyOfPropertyChange(() => this.Datas);
            this.OldID = this.ID;

            this.InRefresh = false;
            this.NotifyOfPropertyChange(() => this.InRefresh);
        }
    }
}
