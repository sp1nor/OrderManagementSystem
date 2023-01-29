using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Persistence;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Controllers;
using Microsoft.Extensions.Logging;
using Catalog.API.Persistence.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Entities;

namespace Catalog.UnitTests;

public class ProductControllerTest
{
    private readonly DbContextOptions<ApplicationContext> _dbOptions;

    public DbSet<Product> Products { get; set; }

    public ProductControllerTest()
	{
        _dbOptions = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "InMem-test")
            .Options;

        using var dbContext = new ApplicationContext(_dbOptions);
        dbContext.AddRange(GetFakeProducts());
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task Get_product_items_success()
    {
        // arrange
        // from fake and default values
        var exprectedTotalItems = 5;

        var context = new ApplicationContext(_dbOptions);

        var integrationServicesMock = new Mock<ILogger<ProductController>>();
        IProductRepository productRepository = new ProductRepository(context);

        // act
        var productController = new ProductController(productRepository, integrationServicesMock.Object);
        var actionResult = await productController.GetAll();

        // assert
        Assert.IsType<ActionResult<IEnumerable<Product>>>(actionResult);
        var col = Assert.IsAssignableFrom<IEnumerable<Product>>(((ObjectResult)(actionResult.Result)).Value);
        Assert.Equal(exprectedTotalItems, col.ToList().Count);
    }

    private List<Product> GetFakeProducts()
    {
        return new List<Product>()
            {
                new Product()
                {
                    Id = 4,
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Samsung 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
            };
    }
}
