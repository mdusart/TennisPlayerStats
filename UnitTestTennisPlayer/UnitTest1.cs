using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesSport;
using System.Web.Http;
using System.Net;
using System.Collections.Generic;

namespace UnitTestTennisPlayer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPlayersList()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();

            var players = tennisPlayerService.GetData();

            Assert.IsNotNull(players);
        }

        [TestMethod]
        public void TestPlayerGoodReturn()
        {
            Player player = new Player();
            player.Id = 52;
            player.FirstName = "Novak";
            player.LastName = "Djokovic";
            player.ShortName = "N.DJO";
            TennisPlayerService tennisPlayerService = new TennisPlayerService();

            Player playerToTest = tennisPlayerService.GetPlayer("52");

            Assert.AreEqual(player.Id, playerToTest.Id);
            Assert.AreEqual(player.FirstName, playerToTest.FirstName);
            Assert.AreEqual(player.LastName, playerToTest.LastName);
            Assert.AreEqual(player.ShortName, playerToTest.ShortName);
        }

        [TestMethod]
        public void TestPlayerExceptionNotExistItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.ThrowsException<HttpResponseException>(() => tennisPlayerService.GetPlayer("aaa"));
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod]
        public void TestPlayerExceptionNotFoundItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.ThrowsException<HttpResponseException>(() => tennisPlayerService.GetPlayer("88"));
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [TestMethod]
        public void TestDeletePlayerExceptionNotExistItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.ThrowsException<HttpResponseException>(() => tennisPlayerService.DeletePlayer("ccc"));
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [TestMethod]
        public void TestDeletePlayerExceptionNotFoundItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.ThrowsException<HttpResponseException>(() => tennisPlayerService.DeletePlayer("99"));
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}
