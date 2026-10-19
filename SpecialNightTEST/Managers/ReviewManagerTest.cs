using DataAccessLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecialNightTEST.MockDALs;
using System.Collections.Generic;

namespace LogicLayer.Tests
{
    [TestClass]
    public class ReviewManagerTest
    {
        [TestMethod]
        public void GetReviews_ReturnsNull()
        {
            // Arrange
            IReviewDAL mockReviewDAL = new FakeReviewDAL();
            var reviewManager = new ReviewManager(mockReviewDAL);

            // Act
            var result = reviewManager.GetReviews();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetReviews_ReturnsNotNull()
        {
            // Arrange
            IReviewDAL mockReviewDAL = new FakeReviewDAL();
            var reviewManager = new ReviewManager(mockReviewDAL);
            reviewManager.AddReviewToDatabase(1, "cool");
            reviewManager.AddReviewToDatabase(2, "awesome!");

            // Act
            var result = reviewManager.GetReviews();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddReviewToDatabase_ReturnsTrue_WhenSuccessful()
        {
            // Arrange
            IReviewDAL mockReviewDAL = new FakeReviewDAL();
            var reviewManager = new ReviewManager(mockReviewDAL);
            var id = 1;
            var text = "Test review";

            // Act
            var result = reviewManager.AddReviewToDatabase(id, text);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteReviewFromDatabase_ReturnsTrue_WhenSuccessful()
        {
            // Arrange
            IReviewDAL mockReviewDAL = new FakeReviewDAL();
            var reviewManager = new ReviewManager(mockReviewDAL);
            var id = 1;

            // Act
            var result = reviewManager.DeleteReviewFromDatabase(id);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
