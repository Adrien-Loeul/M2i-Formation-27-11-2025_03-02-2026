using Exo_1.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo_1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private List<Products> products = new List<Products>()
        {
            new Products() {Id = 1,Nom = "PC", Prix = 50.99},
            new Products() {Id = 2, Nom = "PS4", Prix = 300},
            new Products() {Id = 3, Nom = "PS5", Prix = 499},
            new Products() {Id = 4, Nom = "Xbox", Prix = 200},
            new Products() {Id = 5, Nom = "XboxOne", Prix = 499.99},
            new Products() {Id = 6, Nom = "Switch2", Prix = 449}
        };

        [HttpGet]
        public List<Products> GetAll()
        {
            return products;
        }

        [HttpGet("{id}")]
        public List<Products> GetById(int id)
        {
            return products; 
        }
    }
}
