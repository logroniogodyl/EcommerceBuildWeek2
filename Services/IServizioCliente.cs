using Ecommerce.Models.Entities;

namespace Ecommerce.Services
{
	public interface IServizioCliente
	{
		void AggiungiCliente();
		void RimuoviCliente(int id);
		void ModificaCliente(Cliente c);
		List<Cliente> GetAll();	
		Cliente GetById(int id);
		
     
    }
}