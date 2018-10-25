using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using API.Controllers;
using API.Models.EntityFramework;
using System.Threading.Tasks;

namespace APIUnitTest
{
    [TestClass]
    public class CompteControllerUnitTest
    {

        public CompteController Controller { get; set; }
        public FilmRatingsDBContext Context { get; set; }

        public CompteControllerUnitTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseSqlServer("Server = localhost\\SQLEXPRESS; Database = FilmRatingsDB; Trusted_Connection = True;");
            Context = new FilmRatingsDBContext(builder.Options);
            Controller = new CompteController(Context);
        }

        [TestMethod]
        public async Task TestGetCompteByEmailAsync()
        {
            var email = "paul.durand@gmail.com";

            var controllerResult = await Controller.GetCompteByEmail("paul.durand@gmail.com") as OkObjectResult;

            var dbResult = await Context.Compte
                .Include(c => c.AvisCompte)
                .Include(c => c.FavorisCompte)
                .Where(c => c.Mel.ToLower() == email.ToLower())
                .SingleOrDefaultAsync();

            Assert.IsInstanceOfType(controllerResult.Value, typeof(Compte), "Pas un Compte");
            Assert.AreEqual(dbResult, (Compte)controllerResult.Value, "Comptes pas identiques");
        }
    }
}
