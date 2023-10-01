using MercadoEletro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MercadoEletro.Controllers
{
    public class ProdutoController : Controller
    {
        private static IList<Produto> _produtos = new List<Produto>();
        private static IList<MaterialTipo> _materiais = new List<MaterialTipo>();
        private static int _id = 0;


        [HttpPost]
        public IActionResult DeleteProduto(int id)
        {
            _produtos.Remove(_produtos.First(p => p.Id == id));
            TempData["messageDelete"] = "Produto Removido com sucesso!";
            return RedirectToAction("IndexProduto");
        }
        public IActionResult IndexProduto()
        {
            return View(_produtos);
        }
        [HttpGet]
        public IActionResult EditProduto(int id)
        {
            var produto = _produtos.First(p => p.Id == id);
            produto.Cadastro = produto.Cadastro;
            produto.Atualizacao = DateTime.Now;
            return View(produto);   
        }

        [HttpPost]
        public IActionResult EditProduto(Produto produto)
        {
            var index = _produtos.ToList().FindIndex(p => p.Id == produto.Id);

            produto.Atualizacao = DateTime.Now;
            produto.Cadastro = produto.Cadastro;

            _produtos[index] = produto;

            TempData["messageEdit"] = "Produto Atualizado com sucesso!";
            return RedirectToAction("IndexProduto");
        }

        [HttpGet]
        public IActionResult CreateProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduto(Produto produto)
        {
            var materialTipo = _materiais.FirstOrDefault(m => m.Id == produto.MaterialTipoId);
            if (materialTipo != null)
            {
                produto.MaterialTipo = materialTipo;
            }

            produto.Id = ++_id;
            produto.Cadastro = DateTime.Now;
            produto.Atualizacao = DateTime.Now;

            _produtos.Add(produto);

            TempData["messageCreate"] = "Produto Cadastrado com sucesso!";
            return RedirectToAction("CreateProduto");
        }

    }
}
