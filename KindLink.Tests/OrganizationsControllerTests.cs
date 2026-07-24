using KindLink.Controllers;
using KindLink.Data;
using KindLink.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KindLink.Tests
{
    [TestClass]
    public class OrganizationsControllerTests
    {
        private ApplicationDbContext GetDatabaseContext()
        {
            var options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            var context = new ApplicationDbContext(options);

            context.Organization.AddRange(

                new Organization
                {
                    OrganizationId = 1,
                    Name = "Georgian Mall",
                    Email = "georgianmall@test.ca",
                    PhoneNumber = "1111111111",
                    Address = "Barrie"
                },

                new Organization
                {
                    OrganizationId = 2,
                    Name = "Food Bank",
                    Email = "food@test.ca",
                    PhoneNumber = "2222222222",
                    Address = "Barrie"
                },

                new Organization
                {
                    OrganizationId = 3,
                    Name = "Hospital",
                    Email = "hospital@test.ca",
                    PhoneNumber = "3333333333",
                    Address = "Toronto"
                }

            );

            context.SaveChanges();

            return context;
        }
        [TestMethod]
        public void Edit_Get_ValidId_ReturnsViewResult()
        {
            // Arrange
            var context = GetDatabaseContext();

            var controller =
                new OrganizationsController(context);

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(
                result,
                typeof(ViewResult));
        }
        
        [TestMethod]
        public void Edit_Get_InvalidId_ReturnsNotFound()
        {
            var context = GetDatabaseContext();

            var controller =
                new OrganizationsController(context);

            var result = controller.Edit(99);

            Assert.IsInstanceOfType(
                result,
                typeof(NotFoundResult));
        }
        [TestMethod]
        public void Edit_Post_ValidModel_ReturnsRedirect()
        {
            var context = GetDatabaseContext();

            var controller =
                new OrganizationsController(context);

            var organization =
                context.Organization.First();

            var result =
                controller.Edit(organization);

            Assert.IsInstanceOfType(
                result,
                typeof(RedirectToActionResult));
        }
        [TestMethod]
        public void Edit_Post_ValidModel_RedirectsToIndex()
        {
            var context = GetDatabaseContext();

            var controller =
                new OrganizationsController(context);

            var organization =
                context.Organization.First();

            var result =
                controller.Edit(organization);

            var redirect =
                result as RedirectToActionResult;

            Assert.AreEqual(
                "Index",
                redirect.ActionName);
        }
    }
}