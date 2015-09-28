using Caliburn.Micro;
using Discuz.Api;
using Discuz.Api.Entities;
using Discuz.Api.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ForumIndexViewModel : Screen {

        public BindableCollection<ForumCatalogViewModel> Datas {
            get;
            set;
        }

        public ForumIndexViewModel() {
            this.Datas = new BindableCollection<ForumCatalogViewModel>();

            this.LoadData();
        }

        private async void LoadData() {
            var method = new ForumIndex();
            var catlogs = await ApiClient.GetInstance().Execute(method);
            var datas = catlogs.Select(c => new ForumCatalogViewModel(c));
            this.Datas.AddRange(datas);
        }
    }
}
