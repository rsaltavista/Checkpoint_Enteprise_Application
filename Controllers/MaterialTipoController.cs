using MercadoEletro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MercadoEletro.Controllers
{
    public class MaterialTipoController : Controller
    {
        private static IList<MaterialTipo> _materiais = new List<MaterialTipo>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult DeleteMaterialTipo(int id)
        {
            _materiais.Remove(_materiais.First(p => p.Id == id));
            TempData["messageDeleteMaterial"] = "Tipo de Material Removido com sucesso!";
            return RedirectToAction("IndexMaterialTipo");
        }
        public IActionResult IndexMaterialTipo()
        {
            return View(_materiais);
        }
        [HttpGet]
        public IActionResult EditMaterialTipo(int id)
        {
            var material = _materiais.First(p => p.Id == id);
            return View(material);
        }

        [HttpPost]
        public IActionResult EditMaterialTipo(MaterialTipo material)
        {
            var index = _materiais.ToList().FindIndex(p => p.Id == material.Id);

            _materiais[index] = material;

            TempData["messageEditMaterial"] = "Tipo de Material Atualizado com sucesso!";
            return RedirectToAction("IndexMaterialTipo");
        }

        [HttpGet]
        public IActionResult CreateMaterialTipo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMaterialTipo(MaterialTipo material)
        {
            material.Id = ++_id;

            _materiais.Add(material);

            TempData["messageCreateMaterial"] = "Tipo de Material Cadastrado com sucesso!";

            // Retorna os tipos de materiais atualizados como JSON
            var tiposMateriais = _materiais.Select(m => new { m.Id, m.Descricao });
             Json(tiposMateriais);
            return RedirectToAction("CreateMaterialTipo");
        }


        [HttpGet]
        public IActionResult ObterTiposMateriais()
        {
            var tiposMateriais = _materiais.Select(m => new { m.Id, m.Descricao });
            return Json(tiposMateriais);
        }
    }
}
