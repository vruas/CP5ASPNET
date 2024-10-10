using Microsoft.AspNetCore.Mvc;

using cp5MVC.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace cp5MVC.Controllers
{
    // Existing code
    public class PacienteController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PacienteController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync("Pacientes");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pacientes = JsonSerializer.Deserialize<List<PacienteModel>>(content);
                return View(pacientes);
            }

            return View(new List<PacienteModel>());
        }

        public async Task<IActionResult> Detalhes(int idPaciente)
        {
            var client = _clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync($"Pacientes/{idPaciente}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var paciente = JsonSerializer.Deserialize<PacienteModel>(content);
                return View(paciente);
            }

            return NotFound();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PacienteModel paciente)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIHosp");
                var content = new StringContent(JsonSerializer.Serialize(paciente));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("Pacientes", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(paciente);
        }

        public async Task<IActionResult> Editar(int idPaciente)
        {
            var client = _clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync($"Pacientes/{idPaciente}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var paciente = JsonSerializer.Deserialize<PacienteModel>(content);
                return View(paciente);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int idPaciente, PacienteModel paciente)
        {
            if (idPaciente != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIHosp");
                var content = new StringContent(JsonSerializer.Serialize(paciente));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync($"Pacientes/{idPaciente}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(paciente);
        }

        public async Task<IActionResult> Excluir(int idPaciente)
        {
            var client = _clientFactory.CreateClient("APIHosp");
            var response = await client.GetAsync($"Pacientes/{idPaciente}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var paciente = JsonSerializer.Deserialize<PacienteModel>(content);
                return View(paciente);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExclusao(int idPaciente)
        {
            var client = _clientFactory.CreateClient("APIHosp");
            var response = await client.DeleteAsync($"Pacientes/{idPaciente}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
