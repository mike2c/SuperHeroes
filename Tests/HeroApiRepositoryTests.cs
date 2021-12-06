using Data.Exceptions;
using Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class HeroApiRepositoryTests
    {        
        private IHeroRepository Repository;
        public HeroApiRepositoryTests()
        {
            var config = Configuration.GetInstance();

            string apiUrl = config["BaseUrl"];
            string apiKey = config["ApiKey"];

            Repository = new HeroApiRepository(apiUrl, apiKey);
        }

        [TestMethod]
        [DataRow("super")]
        public async Task GetTaskAsync_ExpectArrayOfHeroes(string search)
        {
            var result = await Repository.GetByNameAsync(search);            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        [DataRow("super")]
        public async Task GetTaskAsync_ExpectSupermanAlways(string search)
        {
            // Arrange
            string heroId = "644";
            string heroName = "Superman";

            // Actual
            var hero = await Repository.GetAsync(644);

            // Assert
            Assert.IsNotNull(hero);
            Assert.AreEqual(heroId, hero.Id);
            Assert.IsNotNull(heroName, hero.Name);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [ExpectedException(typeof(InvalidIdException), "Invalid Id")]        
        public async Task GetAsync_ShouldThrowInvalidIdExceptionAsync(int id)
        {
            await Repository.GetAsync(id);
        }

        [TestMethod]        
        [DataRow(null)]
        [ExpectedException(typeof(Exception))]
        public async Task GetByNameAsync_ShouldThrowException(string search)
        {
            await Repository.GetByNameAsync(search);
        }

        [TestMethod]
        [DataRow("")]
        [ExpectedException(typeof(ApiErrorException), "bad name search request")]
        public async Task GetByNameAsync_ShouldThrowApiErrorException(string search)
        {
            await Repository.GetByNameAsync(search);
        }
    }
}
