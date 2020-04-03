using Entity = PopPopTradingCardsDataAccess.Entities;
using Model = PopPopTradingCardsLib.Models;
using Xunit;
using PopPopTradingCardsDataAccess;

namespace PopPopTradingCardsTest
{
    public class MapperTesting
    {
        // Make sure mapper properly maps an entity user to a model user w/o data loss
        [Fact]
        public void MapUserTesting_EntityModel()
        {
            // Arrange
            var testUser = new Entity.User
            {
                Id = 1,
                Username = "TestUser",
                Password = "qwerty"
            };

            // Act
            var modelUser = Mapper.Map(testUser);

            // Assert
            Assert.Equal(1, modelUser.Id);
            Assert.Equal("TestUser", modelUser.Username);
            Assert.Equal("qwerty", modelUser.Password);
        }

        // Make sure mapper properly maps an entity Magic card to a model 
        // Magic card w/o data loss
        [Fact]
        public void MapMagicCardTesting_EntityModel()
        {
            // Arrange
            var testCard = new Entity.MagicCard
            {
                Id = 1,
                UserId = 1,
                Name = "Llanowar Elves",
                Color = "Green",
                CMC = 1,
                Type = "Creature - Elf Druid",
                Rarity = "Common",
                Booster = "Dominaria",
                Image = "TestImageLink",
                Location = "Binder"
            };

            // Act
            var modelCard = Mapper.Map(testCard);

            // Assert
            Assert.Equal(1, modelCard.Id);
            Assert.Equal(1, modelCard.UserId);
            Assert.Equal("Llanowar Elves", modelCard.Name);
            Assert.Equal("Green", modelCard.Color);
            Assert.Equal(1, modelCard.CMC);
            Assert.Equal("Creature - Elf Druid", modelCard.Type);
            Assert.Equal("Common", modelCard.Rarity);
            Assert.Equal("Dominaria", modelCard.Booster);
            Assert.Equal("TestImageLink", modelCard.Image);
            Assert.Equal("Binder", modelCard.Location);
        }

        // Make sure mapper properly maps an entity baseball card to a model 
        // baseball card w/o data loss
        [Fact]
        public void MapBaseballCardTesting_EntityModel()
        {
            // Arrange
            var testCard = new Entity.BaseballCard
            {
                Id = 1,
                UserId = 1,
                PlayerName = "Babe Ruth",
                Team = "Yankees",
                Year = 1914,
                Image = "TestImageLink",
                Location = "Binder"
            };

            // Act
            var modelCard = Mapper.Map(testCard);

            // Assert
            Assert.Equal(1, modelCard.Id);
            Assert.Equal(1, modelCard.UserId);
            Assert.Equal("Babe Ruth", modelCard.PlayerName);
            Assert.Equal("Yankees", modelCard.Team);
            Assert.Equal(1914, modelCard.Year);
            Assert.Equal("TestImageLink", modelCard.Image);
            Assert.Equal("Binder", modelCard.Location);
        }

        [Fact]
        public void MapMagicCardTesting_ModelEntity()
        {
            // Arrange
            var testCard = new Model.MagicCard
            {
                Id = 1,
                UserId = 1,
                Name = "Llanowar Elves",
                Color = "Green",
                CMC = 1,
                Type = "Creature - Elf Druid",
                Rarity = "Common",
                Booster = "Dominaria",
                Image = "TestImageLink",
                Location = "Binder"
            };

            // Act
            var entityCard = Mapper.Map(testCard);

            // Assert
            Assert.Equal(1, entityCard.Id);
            Assert.Equal(1, entityCard.UserId);
            Assert.Equal("Llanowar Elves", entityCard.Name);
            Assert.Equal("Green", entityCard.Color);
            Assert.Equal(1, entityCard.CMC);
            Assert.Equal("Creature - Elf Druid", entityCard.Type);
            Assert.Equal("Common", entityCard.Rarity);
            Assert.Equal("Dominaria", entityCard.Booster);
            Assert.Equal("TestImageLink", entityCard.Image);
            Assert.Equal("Binder", entityCard.Location);
        }

        [Fact]
        public void MapBaseballCardTesting_ModelEntity()
        {
            // Arrange
            var testCard = new Model.BaseballCard
            {
                Id = 1,
                UserId = 1,
                PlayerName = "Babe Ruth",
                Team = "Yankees",
                Year = 1914,
                Image = "TestImageLink",
                Location = "Binder"
            };

            // Act
            var entityCard = Mapper.Map(testCard);

            // Assert
            Assert.Equal(1, entityCard.Id);
            Assert.Equal(1, entityCard.UserId);
            Assert.Equal("Babe Ruth", entityCard.PlayerName);
            Assert.Equal("Yankees", entityCard.Team);
            Assert.Equal(1914, entityCard.Year);
            Assert.Equal("TestImageLink", entityCard.Image);
            Assert.Equal("Binder", entityCard.Location);
        }
    }
}
