using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
using Restaurant.Core.Services;
using Restaurant.Core.ServicesContracts;
using RestaurantBackend.ServiceTests.CustomFixtureConfiguration;

namespace RestaurantBackend.ServiceTests
{
    public class DishServiceTest
    {
        private readonly IDishService _dishService;

        private readonly Mock<IDishRepository> _dishRepositoryMock;
        private readonly Mock<IRatingRepository> _ratingRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly IFixture _fixture;

        public DishServiceTest()
        {
            _fixture = FixtureFactory.Create();
  
            _dishRepositoryMock = new Mock<IDishRepository>();
            _ratingRepositoryMock = new Mock<IRatingRepository>();
            _mapperMock = new Mock<IMapper>();

            _dishService = new DishService(
                _dishRepositoryMock.Object,
                _mapperMock.Object,
                _ratingRepositoryMock.Object
            );

        }
     
        [Fact]
        public async Task GetDishInfo_ShouldReturnDishDto_WhenDishExists()
        {
            //Arrange
            var dish = _fixture.Create<Dish>();
            var dishDto = _fixture.Create<DishDto>();

            _dishRepositoryMock.Setup(x => x.GetDishInfoAsync(dish.Id))
                .ReturnsAsync(dish);

            _mapperMock.Setup(m => m.Map<DishDto>(dish))
                .Returns(dishDto);

            //Act
            var result = await _dishService.GetDishInfo(dish.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(dishDto);
        }

        [Fact]
        public async Task GetDishInfo_ShouldThrowArgumentNullException_WhenDishIdIsNull()
        {
            Func<Task> act = async () => await _dishService.GetDishInfo(null);

            await act.Should().ThrowAsync<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'dishId is required')");
        }

        [Fact]
        public async Task GetDishPagedList_ShouldReturnMappedPagedList()
        {
            var filterParams = _fixture.Create<DishFilterParams>();
            var dishPage = _fixture.Create<DishPagedList>();
            var dishPageDto = _fixture.Create<DishPagedListDto>();

            _dishRepositoryMock.Setup(x => x.GetAllDishesAsync(filterParams))
                .ReturnsAsync(dishPage);

            _mapperMock.Setup(x => x.Map<DishPagedListDto>(dishPage))
                .Returns(dishPageDto);

            var result = await _dishService.GetDishPagedList(filterParams);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(dishPageDto);
        }

        [Fact]
        public async Task UpdateDishAvgRating_Should_CalculateCorrectAverage_WhenRatingsExist()
        {
            var dishId = Guid.NewGuid();
            var dish = _fixture.Build<Dish>()
                .With(x => x.Id , dishId)
                .Create();

            var ratings = new List<Rating>
            {
                new Rating { Value = 3 },
                new Rating { Value = 4 },
                new Rating { Value = 5 },
            };

            _dishRepositoryMock.Setup(x => x.GetDishInfoAsync(dishId))
                .ReturnsAsync(dish);

            _ratingRepositoryMock.Setup(x => x.GetDishRatings(dishId))
                .ReturnsAsync(ratings);

            _dishRepositoryMock.Setup(x => x.UpdateDishAvgRatingAsync(It.IsAny<Dish>()))
                .Returns(Task.CompletedTask);

            var expected = (float)ratings.Average(x => x.Value);

            //Act
            await _dishService.UpdateDishAvgRating(dishId);

            //Assert
            dish.AverageRating.Should().Be(expected);
        }
    }
}