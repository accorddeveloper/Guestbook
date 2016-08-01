using Guestbook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Guestbook.Controllers.Tests
{
    [TestClass()]
    public class GuestbookControllerTests
    {
        [TestMethod]
        public void Index_RendersView()
        {
            var controller = new GuestbookController(
            new FakeGuestbookRepository());
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index_gets_most_recent_entries()
        {
            var controller = new GuestbookController(
            new FakeGuestbookRepository());
            var result = (ViewResult)controller.Index();
            var guestbookEntries = (IList<GuestbookEntry>)result.Model;
            Assert.AreEqual(1, guestbookEntries.Count);
        }
    }
}