using Caliburn.Micro;
using Discuz.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.ViewModels {
    public class ForumCatalogViewModel : Screen {

        public ForumCatalog Data {
            get;
            private set;
        }

        public ForumCatalogViewModel(ForumCatalog data) {
            this.Data = data;
        }
    }
}
