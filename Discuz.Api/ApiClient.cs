using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.Api {
    public class ApiClient {

        private static ApiClient Instance = null;
        private static object LockObj = new Object();

        public static ApiClient GetInstance() {
            if (Instance == null) {
                lock (LockObj) {
                    Instance = new ApiClient();
                }
            }
            return Instance;
        }


        private ApiClient() {

        }

        public string GetUrl(MethodBase method) {
            return string.Format("http://bbs.blueidea.com/api/mobile/index.php?mobile=no&version=1&module={0}", method.Module);
        }

        public async Task<TResult> Execute<TResult>(MethodBase<TResult> method) {
            return await method.Execute(this);
        }
    }
}
