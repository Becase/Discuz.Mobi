using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Discuz.Api.Methods;

namespace Discuz.Api.Test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestIndex() {

            var client = ApiClient.GetInstance();
            var method = new ForumIndex();
            var result = client.Execute(method).Result;
        }
    }
}
