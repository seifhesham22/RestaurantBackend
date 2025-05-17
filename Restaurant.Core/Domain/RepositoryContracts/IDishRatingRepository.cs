using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IDishRatingRepository
    {
        /// <summary>
        /// Checks if user is able to set rating of the dish
        /// </summary>
        /// <param name="id">The unique identifier of the dish.</param>
        /// <returns>True if user is able; otherwise, false.</returns>
        Task<bool> CanRate(Guid id);
        /// <summary>
        /// Sets a rate for certain dish
        /// </summary>
        /// <param name="id">The unique identifier of the dish.</param>
        /// <param name="rating">Rating the user defines</param>
        void SetRating(Guid id, int rating);
    }
}
