using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface ICartService
    {
        Task<List<DishCartDto>> GetUserCart(Guid userId);
    }
}
