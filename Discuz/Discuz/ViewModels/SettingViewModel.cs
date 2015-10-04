using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Discuz.ViewModels {
    public class SettingViewModel : Screen {

        public ICommand EditFavoriteCmd {
            get;
            set;
        }

        public SettingViewModel(INavigationService ns) {
            this.DisplayName = "设置";

            this.EditFavoriteCmd = new Command(() => {
                ns.For<FavoriteViewModel>()
                    .Navigate();
            });
        }

    }
}
