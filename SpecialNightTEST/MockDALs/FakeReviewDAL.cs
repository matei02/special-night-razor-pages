using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNightTEST.MockDALs
{
    public class FakeReviewDAL : IReviewDAL
    {
        private Dictionary<int, List<string>> reviews;
        List<string> texts;
        public FakeReviewDAL() 
        {
            reviews = new Dictionary<int, List<string>>();
            texts = new List<string>();
        }

        public bool AddReviewToDatabase(int? id, string text)
        {
            
            if (id!=null && !string.IsNullOrEmpty(text))
            {
                texts.Add(text);
                reviews.Add((int)id, texts);
                return true;
            }
            return false;
        }

        public bool DeleteReviewFromDatabase(int? id)
        {
            if (id != null)
            {
                reviews.Remove((int)id);
                return true;
            }
            else return false;
        }

        public Dictionary<int, List<string>>? GetReviewsFromDatabase()
        {
            if (reviews.Count == 0) return null;
            return reviews;
        }
    }
}
