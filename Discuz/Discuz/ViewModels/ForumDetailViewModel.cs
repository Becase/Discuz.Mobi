using Caliburn.Micro;
using Discuz.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ForumDetailViewModel : Screen {

        public Forum Data {
            get;
            private set;
        }

        public ForumDetailViewModel(Forum data) {
            this.Data = data;
        }
    }
}
