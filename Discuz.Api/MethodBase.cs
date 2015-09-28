using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discuz.Api {
    public abstract class MethodBase {

        /// <summary>
        /// 模块
        /// </summary>
        public abstract string Module {
            get;
        }

        public async virtual Task<string> GetResult(ApiClient client) {
            var url = this.BuildUrl(client.GetUrl(this));
            HttpClient hc = new HttpClient();
            return await hc.GetStringAsync(url);
        }
    }

    public abstract class MethodBase<TResult> : MethodBase {

        internal async virtual Task<TResult> Execute(ApiClient client) {
            var result = await this.GetResult(client);
            return JsonConvert.DeserializeObject<TResult>(result);
        }

    }
}
