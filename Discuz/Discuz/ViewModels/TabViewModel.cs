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

        private SortedDictionary<int, string> Favorites = null;

        public TabViewModel(SimpleContainer container) {
            this.Container = container;
            this.Favorites = PropertiesHelper.GetObject<SortedDictionary<int, string>>("Favorites") ?? new SortedDictionary<int, string>();

            this.Datas = new BindableCollection<Screen>();
            var index = container.GetInstance<ForumIndexViewModel>();
            var setting = container.GetInstance<SettingViewModel>();

            this.Datas.Add(index);
            this.Datas.Add(setting);

            foreach (var kv in this.Favorites) {
                this.ShowFavorite(kv.Key, kv.Value);
            }

            this.RegistMessageCenter();
        }

        private void RegistMessageCenter() {
            MessagingCenter.Subscribe<ForumDetailViewModel, Tuple<int, string>>(this, ForumDetailViewModel.AddFavoriteMessage, (sender, arg) => {
                if (!this.Favorites.ContainsKey(arg.Item1)) {
                    this.ShowFavorite(arg.Item1, arg.Item2);
                    this.AddToFavorite(arg.Item1, arg.Item2);
                }
            });
        }

        private void ShowFavorite(int forumID, string name) {
            var vm = this.Container.GetInstance<ForumDisplayViewModel>("ForFavorite");
            vm.ID = forumID;
            vm.DisplayName = name;
            this.Datas.Add(vm);
        }

        private async void AddToFavorite(int forumID, string name) {
            if (!this.Favorites.ContainsKey(forumID)) {
                this.Favorites.Add(forumID, name);
                PropertiesHelper.SetObject("Favorites", this.Favorites);
                await PropertiesHelper.Save();
            }
        }
    }
}
