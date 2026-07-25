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
            var controller = new OrganizationsController(context);
    
            // Act
            var result = controller.Edit(1);
    
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult)); 
        }
        
        [TestMethod]
        public void Edit_Get_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);

            // Act
            var result = controller.Edit(99);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        
        [TestMethod]
        public void Edit_Post_ValidModel_ReturnsRedirect()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);
            var organization = context.Organization.First();

            // Act
            var result = controller.Edit(organization);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        
        [TestMethod]
        public void Edit_Post_ValidModel_RedirectsToIndex() 
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);
            var organization = context.Organization.First();
    
            // Act
            var result = controller.Edit(organization);
    
            // Assert
            var redirect = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirect.ActionName); 
        }
        
        [TestMethod]
        public void Edit_Post_UpdatesDatabase()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);
    
            var organization = context.Organization.Find(1);
            organization.Name = "Updated Name";

            // Act
            controller.Edit(organization);

            // Assert
            var updated = context.Organization.Find(1);
            Assert.AreEqual("Updated Name", updated.Name);
        }
        
        [TestMethod]
        public void Edit_Post_InvalidModel_ReturnsView()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);
    
            controller.ModelState.AddModelError("Name", "Required");
            var organization = context.Organization.First();

            // Act
            var result = controller.Edit(organization);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        
        [TestMethod]
        public void Edit_Post_InvalidModel_DoesNotUpdateDatabase()
        {
            // Arrange
            var context = GetDatabaseContext();
            var controller = new OrganizationsController(context);
    
            controller.ModelState.AddModelError("Name", "Required");
            var organization = context.Organization.Find(1);
            organization.Name = "Changed";

            // Act
            controller.Edit(organization);

            // Assert
            var original = context.Organization.Find(1);
            Assert.AreEqual("Changed", original.Name);
        }
    }
}