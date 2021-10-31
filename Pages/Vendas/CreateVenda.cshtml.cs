using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ControleDeEstoque.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ControleDeEstoque.Pages.Vendas
{
    public class CreateVendaModel : PageModel
    {
        [BindProperty]
        public Venda Venda { get; set; }

        string baseUrl = "https://localhost:44338";
        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client
                    .PostAsJsonAsync("api/Venda", Venda);

                if (response.IsSuccessStatusCode)
                {
                    //Produtos/Index
                    return RedirectToPage("./Index");
                } else
                {
                    return RedirectToPage("./CreateVenda");
                }
            }
        }
    }
}