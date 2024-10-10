using Microsoft.AspNetCore.Mvc;

using cp5MVC.Models;
using System.Text.Json;
using System.Net.Http.Headers;


namespace cp5MVC.Controllers
{
    public class PlanoSaudeController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public PlanoSaudeController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync("PlanosDeSaude");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var planosDeSaude = JsonSerializer.Deserialize<List<PlanoSaudeModel>>(content);
                return View(planosDeSaude);
            }

            return View(new List<PlanoSaudeModel>());
        }

        public async Task<IActionResult> Detalhes(int idPlanoDeSaude)
        {
            var client = clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync($"PlanosDeSaude/{idPlanoDeSaude}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var planoDeSaude = JsonSerializer.Deserialize<PlanoSaudeModel>(content);
                return View(planoDeSaude);
            }

            return NotFound();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PlanoSaudeModel planoDeSaude)
        {
            if (ModelState.IsValid)
            {
                var client = clientFactory.CreateClient("APIHosp");
                var content = new StringContent(JsonSerializer.Serialize(planoDeSaude));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("PlanosDeSaude", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(planoDeSaude);
        }

        public async Task<IActionResult> Editar(int idPlanoDeSaude)
        {
            var client = clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync($"PlanosDeSaude/{idPlanoDeSaude}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var planoDeSaude = JsonSerializer.Deserialize<PlanoSaudeModel>(content);
                return View(planoDeSaude);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int idPlanoDeSaude, PlanoSaudeModel planoSaude)
        {
            if (idPlanoDeSaude != planoSaude.IdPlanoDeSaude)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = clientFactory.CreateClient("APIHosp");
                var content = new StringContent(JsonSerializer.Serialize(planoSaude));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync($"PlanosDeSaude/{idPlanoDeSaude}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(planoSaude);
        }

        public async Task<IActionResult> Excluir(int idPlanoDeSaude)
        {
            var client = clientFactory.CreateClient("APIHosp");
            var response = await client.DeleteAsync($"PlanosDeSaude/{idPlanoDeSaude}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpPost, ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExclusao(int idPlanoDeSaude)
        {
            var client = clientFactory.CreateClient("APIHosp");
            var response = await client.DeleteAsync($"PlanosDeSaude/{idPlanoDeSaude}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
