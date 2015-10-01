using Caliburn.Micro;
using Discuz.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Discuz.ViewModels {
    public class TabViewModel : Screen {

        private SimpleContainer Container = null;

        public BindableCollection<Screen> Datas {
            get;
            set;
        }

        public TabViewModel(SimpleContainer container) {
            this.Container = container;

            this.Datas = new BindableCollection<Screen>();
            var index = container.GetInstance<ForumIndexViewModel>();
            var setting = container.GetInstance<SettingViewModel>();

            this.Datas.Add(index);
            this.Datas.Add(setting);

            this.RegistMessageCenter();
        }

        private void RegistMessageCenter() {
            MessagingCenter.Subscribe<ForumDetailViewModel, Tuple<int, string>>(this, ForumDetailViewModel.AddFavoriteMessage, (sender, arg) => {
                this.AddToFavorite(arg.Item1, arg.Item2);
            });
        }

        private void AddToFavorite(int forumID, string name) {
            var vm = this.Container.GetInstance<ForumDisplayViewModel>("ForFavorite");
            vm.ID = forumID;
            vm.DisplayName = name;
            this.Datas.Insert(0, vm);
        }
    }
}
