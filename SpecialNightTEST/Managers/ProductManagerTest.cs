using DataAccessLayer;
using DomainsLayer;
using DomainsLayer.Classes;
using SpecialNightTEST.MockDALs;
using System.Collections.Generic;

namespace LogicLayer.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        private ProductManager productManager;
        private FakeProductDAL fakeProductDAL;

        [TestInitialize]
        public void TestInitialize()
        {
            // Create a new instance of the FakeProductDAL
            fakeProductDAL = new FakeProductDAL();

            // Create a new instance of the ProductManager with the FakeProductDAL
            productManager = new ProductManager(fakeProductDAL);
        }

        [TestMethod]
        public void GetNecklacesStock_ShouldReturnListOfNecklaces()
        {
            // Arrange
            productManager.AddNecklaceToDatabase(new Necklace(1, Material.GOLD, 12, "gold necklace", 3));

            // Act
            var actual = productManager.GetNecklacesStock();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetBraceletsStock_ShouldReturnListOfBracelets()
        {
            // Arrange
            productManager.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            var actual = productManager.GetBraceletsStock();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetEarringsStock_ShouldReturnListOfEarrings()
        {
            // Arrange
            productManager.AddEarringsToDatabase(new Earring(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            var actual = productManager.GetEarringsStock();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetDressesStock_ShouldReturnListOfDresses()
        {
            // Arrange
            productManager.AddDressToDatabase(new Dress(1, DressColors.RED, 30, 30, 30, "red dress", 2, 50));

            // Act
            var actual = productManager.GetDressesStock();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetSuitsStock_ShouldReturnListOfSuits()
        {
            // Arrange
            productManager.AddSuitToDatabase(new Suit(1, SuitColors.NAVY, 30, 30, 30, "red dress", 2, 50));

            // Act
            var actual = productManager.GetSuitsStock();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetAllProductsFromDatabase_ShouldReturnListOfProducts()
        {
            // Arrange
            productManager.AddSuitToDatabase(new Suit(1, SuitColors.NAVY, 30, 30, 30, "red dress", 2, 50));
            productManager.AddDressToDatabase(new Dress(1, DressColors.RED, 30, 30, 30, "red dress", 2, 50));
            productManager.AddEarringsToDatabase(new Earring(2, Material.GOLD, 21, "gold necklace", 3));
            productManager.AddNecklaceToDatabase(new Necklace(1, Material.GOLD, 12, "gold necklace", 3));
            productManager.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            var actual = productManager.GetAllProductsFromDatabase();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteBraceletFromDatabase_ShouldReturnValid()
        {
            // Arrange
            productManager.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            var actual = productManager.RemoveBraceletFromDatabase(2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteDressFromDatabase_ShouldReturnValid()
        {
            // Arrange
            productManager.AddDressToDatabase(new Dress(1, DressColors.RED, 30, 30, 30, "red dress", 2, 50));

            // Act
            var actual = productManager.RemoveDressFromDatabase(1);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteSuitFromDatabase_ShouldReturnValid()
        {
            // Arrange
            productManager.AddSuitToDatabase(new Suit(1, SuitColors.NAVY, 30, 30, 30, "red dress", 2, 50));

            // Act
            var actual = productManager.RemoveSuitFromDatabase(1);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteEarringFromDatabase_ShouldReturnValid()
        {
            // Arrange
            productManager.AddEarringsToDatabase(new Earring(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            var actual = productManager.RemoveEarringFromDatabase(2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteNecklaceFromDatabase_ShouldReturnValid()
        {
            // Arrange
            productManager.AddNecklaceToDatabase(new Necklace(1, Material.GOLD, 12, "gold necklace", 3));

            // Act
            var actual = productManager.RemoveNecklaceFromDatabase(1);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GetBraceletByID_ShouldReturnObject()
        {
            // Arrange
            productManager.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            Bracelet var = productManager.GetBraceletByID(2);

            // Assert
            Assert.IsNotNull(var);
        }

        [TestMethod]
        public void GetDressByID_ShouldReturnObject()
        {
            // Arrange
            productManager.AddDressToDatabase(new Dress(1, DressColors.RED, 30, 30, 30, "red dress", 2, 50));

            // Act
            Dress var = productManager.GetDressByID(1);

            // Assert
            Assert.IsNotNull(var);
        }

        [TestMethod]
        public void GetEarringByID_ShouldReturnObject()
        {
            // Arrange
            productManager.AddEarringsToDatabase(new Earring(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            Earring var = productManager.GetEarringByID(2);

            // Assert
            Assert.IsNotNull(var);
        }

        [TestMethod]
        public void GetNecklaceByID_ShouldReturnObject()
        {
            // Arrange
            productManager.AddNecklaceToDatabase(new Necklace(1, Material.GOLD, 12, "gold necklace", 3));

            // Act
            Necklace var = productManager.GetNecklaceByID(1);

            // Assert
            Assert.IsNotNull(var);
        }

        [TestMethod]
        public void GetSuitByID_ShouldReturnObject()
        {
            // Arrange
            productManager.AddSuitToDatabase(new Suit(1, SuitColors.NAVY, 30, 30, 30, "red dress", 2, 50));

            // Act
            Suit var = productManager.GetSuitByID(1);

            // Assert
            Assert.IsNotNull(var);
        }

        [TestMethod]
        public void UpdateBracelet_ShouldReturnTrue()
        {
            // Arrange
            productManager.AddBraceletToDatabase(new Bracelet(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            Bracelet var = productManager.GetBraceletByID(2);
            var.Quantity = 100;
            bool ok = productManager.UpdateBraceletInDatabase(var, 2);

            // Assert
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void UpdateDress_ShouldReturnTrue()
        {
            // Arrange
            productManager.AddDressToDatabase(new Dress(1, DressColors.RED, 30, 30, 30, "red dress", 2, 50));

            // Act
            Dress var = productManager.GetDressByID(1);
            var.Quantity = 100;
            bool ok = productManager.UpdateDressInDatabase(var, 1);

            // Assert
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void UpdateEarrings_ShouldReturnTrue()
        {
            // Arrange
            productManager.AddEarringsToDatabase(new Earring(2, Material.GOLD, 21, "gold necklace", 3));

            // Act
            Earring var = productManager.GetEarringByID(2);
            var.Quantity = 100;
            bool ok = productManager.UpdateEarringsInDatabase(var, 2);

            // Assert
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void UpdateNecklace_ShouldReturnTrue()
        {
            // Arrange
            productManager.AddNecklaceToDatabase(new Necklace(1, Material.GOLD, 12, "gold necklace", 3));

            // Act
            Necklace var = productManager.GetNecklaceByID(1);
            var.Quantity = 100;
            bool ok = productManager.UpdateNecklaceInDatabase(var, 1);

            // Assert
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void UpdateSuit_ShouldReturnTrue()
        {
            // Arrange
            productManager.AddSuitToDatabase(new Suit(1, SuitColors.NAVY, 30, 30, 30, "red dress", 2, 50));

            // Act
            Suit var = productManager.GetSuitByID(1);
            var.Quantity = 100;
            bool ok = productManager.UpdateSuitInDatabase(var, 1);

            // Assert
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void DeleteProductByID_ShouldRemoveProduct()
        {
            productManager.AddBraceletToDatabase(new Bracelet(20, Material.GOLD, 21, "fake", 12));

            bool ok = productManager.DeleteProductByID(20);
            
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void DeleteProductByID_InvalidID()
        {
            productManager.AddBraceletToDatabase(new Bracelet(20, Material.GOLD, 21, "fake", 12));

            bool ok = productManager.DeleteProductByID(10);

            Assert.IsFalse(ok);
        }

        [TestMethod]
        public void DeleteProductByID_ShouldReturnFalse()
        {
            productManager.AddBraceletToDatabase(new Bracelet(20, Material.GOLD, 21, "fake", 12));

            bool ok = productManager.DeleteProductByID(-2);

            Assert.IsFalse(ok);
        }

    }
}
