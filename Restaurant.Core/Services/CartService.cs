using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Domain.DbContextInterface;
using Restaurant.Core.Domain.IdentityEntities;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Restaurant.Core.Services
{
    public class CartService : ICartService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _db;
        public CartService(IApplicationDbContext db , UserManager<ApplicationUser> user)
        {
            _db = db;
            _userManager = user;

        }

        public async Task<List<DishCartDto>> GetUserCart(Guid userId)
        {
            if(userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId));
            var userExist = await _userManager.Users.(x => x.UserId == userId);
        }
    }
}
