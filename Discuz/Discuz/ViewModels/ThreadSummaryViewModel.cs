using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Discuz.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ThreadSummaryViewModel : Screen {

        public ThreadSummary Data {
            get;
            private set;
        }

        private INavigationService NS = null;

        public ThreadSummaryViewModel(ThreadSummary data, INavigationService ns) {
            this.Data = data;
            this.NS = ns;
        }

    }
}
