
using Ecommerce.Models.Entities;

namespace Ecommerce.Models
{
	public class CarrelloViewModel
	{
		//pagina carrello
		public int IdCarrelloProdotto { get; set; }

		public IEnumerable<CarrelloProdotto> CarrelloProdotti { get; set; } = new List<CarrelloProdotto>();
		
        public Carrello Carrello { get; set; }
		public Prodotto Prodotto { get; set; }
		public decimal Totale { get; set; }
	}

}
