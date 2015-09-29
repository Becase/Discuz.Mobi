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

        [TestMethod]
        public void ForumDisplayTest() {
            var client = ApiClient.GetInstance();
            var method = new ForumDisplay() {
                ForumID = 23,
                PageSize = 10
            };
            var result = client.Execute(method).Result;
        }

        [TestMethod]
        public void ViewThreadTest() {
            var client = ApiClient.GetInstance();
            var method = new ViewThread() {
                ThreadID = 2663379
            };
            var result = client.Execute(method).Result;
        }
    }
}
