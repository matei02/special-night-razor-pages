using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewDAL
    {
        Dictionary<int, List<string>>? GetReviewsFromDatabase();

        bool AddReviewToDatabase(int? id, string text);

        bool DeleteReviewFromDatabase(int? id);
    }
}
