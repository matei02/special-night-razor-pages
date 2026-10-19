using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ReviewManager
    {
        private IReviewDAL IReviewDAL;

        public ReviewManager(IReviewDAL iReviewDAL)
        {
            IReviewDAL = iReviewDAL;
        }

        public Dictionary<int, List<string>>? GetReviews()
        {
            return IReviewDAL.GetReviewsFromDatabase();
        }

        public bool AddReviewToDatabase(int? id, string text)
        {
            return IReviewDAL.AddReviewToDatabase(id, text);
        }

        public bool DeleteReviewFromDatabase(int id)
        {
            return IReviewDAL.DeleteReviewFromDatabase(id);
        }
    }
}
