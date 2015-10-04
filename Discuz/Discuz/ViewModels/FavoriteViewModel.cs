using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class FavoriteViewModel : Screen {

        public SortedDictionary<int, string> Datas {
            get;
            set;
        }

        protected override void OnActivate() {
            base.OnActivate();

            this.Datas = PropertiesHelper.GetObject<SortedDictionary<int, string>>("Favorites") ?? new SortedDictionary<int, string>();
            this.NotifyOfPropertyChange(() => this.Datas);
        }

    }
}
