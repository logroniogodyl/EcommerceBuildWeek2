

using Ecommerce.Models.Entities;

namespace Ecommerce.Models
{
	public class ProdottoViewModel
	{
		////public IEnumerable<Prodotto> listProdotto { get; set; } = new List<Prodotto>();
		public int IdProdotto { get; set; }
		public string Nome { get; set; }
		public string Immagine { get; set; }
		public decimal Prezzo { get; set; }
	}
   
}
