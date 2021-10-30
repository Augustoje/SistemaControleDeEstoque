using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ControleDeEstoque.Pages
{
    public class IndexModel : PageModel
    {
        public List<Produto> Produtos { get; private set; }
        public List<Venda> ProdutoMaisVendido { get; private set; }
        public int Estoque { get; private set; }
        string baseUrl = "https://localhost:44338";
        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Produto");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Produtos = JsonConvert.DeserializeObject<List<Produto>>(result);
                }

                await GetEstoque();
                await GetMaisVendido();
            }
        }
        public async Task GetEstoque()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Produto/Quantidade-Estoque");
                if (response.IsSuccessStatusCode)
                {
                    string resultEstoque = response.Content.ReadAsStringAsync().Result;
                    Estoque = JsonConvert.DeserializeObject<int>(resultEstoque);
                }
            }
        }

        public async Task GetUltimaSaida()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Produto/Quantidade-Estoque");
                if (response.IsSuccessStatusCode)
                {
                    string resultEstoque = response.Content.ReadAsStringAsync().Result;
                    Estoque = JsonConvert.DeserializeObject<int>(resultEstoque);
                }
            }
        }

        public async Task GetMaisVendido()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Venda/Mais-Vendido");
                if (response.IsSuccessStatusCode)
                {
                    string resultMaisVendido = response.Content.ReadAsStringAsync().Result;
                    ProdutoMaisVendido = JsonConvert.DeserializeObject<List<Venda>>(resultMaisVendido);
                }
            }
        }
    }
}

