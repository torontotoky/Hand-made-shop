using HandMadeShop.bll.Interfaces;
using HandMadeShop.bll.models;
using Microsoft.AspNetCore.Mvc;

namespace Hand_made_shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
            var materials = this.materialService.GetMaterials();

            return new JsonResult(materials);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(string name)
        {
            var bMaterial = new BMaterial() { Name = name };
            var newMaterial = await this.materialService.CreateMaterial(bMaterial);

            return new JsonResult(newMaterial);
        }
    }
}
