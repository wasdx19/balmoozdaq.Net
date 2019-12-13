using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using balmoozdaq.Services;
using Moq;
using Xunit;

namespace balmoozdaqTest
{
    public class CenterServiceTesting
    {
        [Fact]
        public async Task AddAndSaveTest()
        {
            var fakeRepo = Mock.Of<ICenterRepo>();
            var centerService = new CenterService(fakeRepo);
            var center = new Center { Id = 1, Name = "qwer", Description = "qwer",Phone="870248404845",Address="Sapaeva 43" };
            await centerService.AddAndSave(center);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepo = Mock.Of<ICenterRepo>();
            var centerService = new CenterService(fakeRepo);
            var center = new Center { Id = 1, Name = "qwer", Description = "qwer", Phone = "870248404845", Address = "Sapaeva 43" };
            await centerService.Update(center);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepo = Mock.Of<ICenterRepo>();
            var centerService = new CenterService(fakeRepo);
            var center = new Center { Id = 1, Name = "qwer", Description = "qwer", Phone = "870248404845", Address = "Sapaeva 43" };
            await centerService.Delete(center);
        }

        [Fact]
        public async Task GetUsers()
        {
            var centers = new List<Center>
            {
                new Center{Id = 1, Name = "qwer", Description = "qwer", Phone = "870248404845", Address = "Sapaeva 43" },
                new Center{Id = 2, Name = "qwer1", Description = "qwer1", Phone = "870248404846", Address = "Sapaeva 44"}
            };

            var fakeRepo = new Mock<ICenterRepo>();
            fakeRepo.Setup(x => x.GetAll()).ReturnsAsync(centers);

            var centerService = new CenterService(fakeRepo.Object);
            var resultCenters = await centerService.GetCenter();

            Assert.Collection(resultCenters, center =>
            {
                Assert.Equal("qwer", center.Name);
            },
            center =>
            {
                Assert.Equal("qwer1", center.Name);
            });
        }
    }
}
