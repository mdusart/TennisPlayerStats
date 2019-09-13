using NUnit.Framework;
using ServicesSport;
using System.Net;
using System.Web.Http;

namespace TestProjectTennisPlayer
{
    [TestFixture]
    public class PlayerServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPlayersList()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();

            var players = tennisPlayerService.GetData();

            Assert.AreEqual(players, Is.All.Not.Null);
            Assert.AreEqual(players, Is.All.InstanceOf<Player>());
        }

        [Test]
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

        [Test]
        public void TestPlayerExceptionNotExistItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.Throws<HttpResponseException>(() => tennisPlayerService.GetPlayer("aaa"));
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [Test]
        public void TestPlayerExceptionNotFoundItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.Throws<HttpResponseException>(() => tennisPlayerService.GetPlayer("88"));
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }

        [Test]
        public void TestDeletePlayerExceptionNotExistItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.Throws<HttpResponseException>(() => tennisPlayerService.DeletePlayer("ccc"));
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [Test]
        public void TestDeletePlayerExceptionNotFoundItem()
        {
            TennisPlayerService tennisPlayerService = new TennisPlayerService();
            var ex = Assert.Throws<HttpResponseException>(() => tennisPlayerService.DeletePlayer("99"));
            Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }   
}