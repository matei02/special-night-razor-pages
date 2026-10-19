using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecialNightTEST.MockDALs;
using System.Collections.Generic;

namespace DataAccessLayer.Tests
{
    [TestClass]
    public class FakeShoppingCartDALTests
    {
        private FakeShoppingCartDAL fakeShoppingCartDAL;
        private FakeProductDAL fakeProductDAL;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            fakeShoppingCartDAL = new FakeShoppingCartDAL();
            fakeProductDAL = new FakeProductDAL();

            fakeProductDAL.AddBraceletToDatabase(new Bracelet(1, Material.GOLD, 20, "bracelet", 2));
        }

        [TestMethod]
        public void AddToShoppingCart_ShouldAddProduct_WhenValidPersonIDAndProductID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeProductDAL.AddBraceletToDatabase(new Bracelet(1, Material.GOLD, 20, "bracelet", 2));

            // Act
            bool result = fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, fakeShoppingCartDAL.GetAllShoppingCartProducts(personID).Count);
        }

        [TestMethod]
        public void AddToShoppingCart_ShouldNotAddProduct_WhenPersonIDIsNull()
        {
            // Arrange
            int? personID = null;
            int productID = 1;

            // Act
            bool result = fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, fakeShoppingCartDAL.GetAllShoppingCartProducts(personID).Count);
        }

        [TestMethod]
        public void GetAllShoppingCartProducts_ShouldReturnProducts_WhenValidPersonID()
        {
            // Arrange
            int personID = 1;
            int productID1 = 1;
            int productID2 = 2;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID1);
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID2);

            // Act
            List<Product> products = fakeShoppingCartDAL.GetAllShoppingCartProducts(personID);

            // Assert
            Assert.AreEqual(2, products.Count);
            Assert.IsTrue(products.Exists(p => p.GetID() == productID1));
            Assert.IsTrue(products.Exists(p => p.GetID() == productID2));
        }

        [TestMethod]
        public void GetAllShoppingCartProducts_ShouldReturnEmptyList_WhenPersonIDDoesNotExist()
        {
            // Arrange
            int personID = 1;

            // Act
            List<Product> products = fakeShoppingCartDAL.GetAllShoppingCartProducts(personID);

            // Assert
            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void GetTotal_ShouldReturnTotalPrice_WhenValidPersonID()
        {
            // Arrange
            int personID = 1;
            int productID1 = 1;
            int productID2 = 2;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID1);
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID2);

            // Act
            int total = fakeShoppingCartDAL.GetTotal(personID);

            // Assert
            Assert.AreEqual(40, total); // Assuming product prices are 20 each
        }

        [TestMethod]
        public void GetTotal_ShouldReturnZero_WhenPersonIDDoesNotExist()
        {
            // Arrange
            int personID = 1;

            // Act
            int total = fakeShoppingCartDAL.GetTotal(personID);

            // Assert
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void RemoveFromShoppingCart_ShouldRemoveProduct_WhenValidPersonIDAndProductID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Act
            bool result = fakeShoppingCartDAL.RemoveFromShoppingCart(personID, productID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, fakeShoppingCartDAL.GetAllShoppingCartProducts(personID).Count);
        }

        [TestMethod]
        public void RemoveFromShoppingCart_ShouldNotRemoveProduct_WhenPersonIDIsNull()
        {
            // Arrange
            int? personID = null;
            int productID = 1;

            // Act
            bool result = fakeShoppingCartDAL.RemoveFromShoppingCart(personID, productID);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IncreaseQuantityInCart_ShouldIncreaseProductQuantity_WhenValidPersonIDAndProductID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Act
            bool result = fakeShoppingCartDAL.IncreaseQuantityInCart(personID, productID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, fakeShoppingCartDAL.GetItemQuantity(productID, personID));
        }

        [TestMethod]
        public void IncreaseQuantityInCart_ShouldNotIncreaseProductQuantity_WhenPersonIDIsNull()
        {
            // Arrange
            int? personID = null;
            int productID = 1;

            // Act
            bool result = fakeShoppingCartDAL.IncreaseQuantityInCart(personID, productID);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DecreaseQuantityInCart_ShouldDecreaseProductQuantity_WhenValidPersonIDAndProductID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Act
            fakeShoppingCartDAL.IncreaseQuantityInCart(personID, productID);
            bool result = fakeShoppingCartDAL.DecreaseQuantityInCart(personID, productID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, fakeShoppingCartDAL.GetItemQuantity(productID, personID));
        }

        [TestMethod]
        public void DecreaseQuantityInCart_ShouldNotDecreaseProductQuantity_WhenPersonIDIsNull()
        {
            // Arrange
            int? personID = null;
            int productID = 1;

            // Act
            bool result = fakeShoppingCartDAL.DecreaseQuantityInCart(personID, productID);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ClearShoppingCart_ShouldClearProducts_WhenValidPersonID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Act
            bool result = fakeShoppingCartDAL.ClearShoppingCart(personID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, fakeShoppingCartDAL.GetAllShoppingCartProducts(personID).Count);
        }

        [TestMethod]
        public void ClearShoppingCart_ShouldNotClearProducts_WhenPersonIDIsNull()
        {
            // Arrange
            int? personID = null;

            // Act
            bool result = fakeShoppingCartDAL.ClearShoppingCart(personID);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetItemQuantity_ShouldReturnQuantity_WhenValidPersonIDAndProductID()
        {
            // Arrange
            int personID = 1;
            int productID = 1;
            fakeShoppingCartDAL.AddToShoppingCart(personID, productID);

            // Act
            int quantity = fakeShoppingCartDAL.GetItemQuantity(productID, personID);

            // Assert
            Assert.AreEqual(1, quantity);
        }

        [TestMethod]
        public void GetItemQuantity_ShouldReturnZero_WhenPersonIDOrProductIDIsInvalid()
        {
            // Arrange
            int personID = 4;
            int productID = 5;

            // Act
            int quantity = fakeShoppingCartDAL.GetItemQuantity(productID, personID);

            // Assert
            Assert.AreEqual(0, quantity);
        }
    }
}
