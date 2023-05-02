using Ecommerce.Models.Entities;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Services
{
	public class ServizioCliente : IServizioCliente
	{
		private SqlConnection connection;


		public ServizioCliente(IConfiguration configuration)
		{
			connection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
		}
		public void AggiungiCliente()
		{


          
            throw new NotImplementedException();
        }
		public void RimuoviCliente(int id)
		{
			throw new NotImplementedException();
		}

		public void ModificaCliente(Cliente c)
		{
			throw new NotImplementedException();
		}

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }
        //public void AggiungiProdottoAlCarrello(int idcarrello, int idprodotto, int quantita)
    
        //{
           
        //    var cmd = connection.CreateCommand();
        //    cmd.CommandText = "insert into CarrelloProdotto (IdCarrello,IdProdotto,Quantita)Values(@idcarrello,@idprodotto,@quantita)";
           
        //    cmd.Parameters.AddWithValue("@idcarrello", idcarrello);
        //    cmd.Parameters.AddWithValue("@idprodotto", idprodotto);
        //    cmd.Parameters.AddWithValue("@quantita", quantita);
        //   connection.Open();
        //    cmd.ExecuteNonQuery();
        //    connection.Close();
          
        //    }

      
    }

}

