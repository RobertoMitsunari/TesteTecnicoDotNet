namespace TesteTecnicoDotNet.Business.Models
{
	public class Cliente : Entity
	{
		public required string Nome { get; set; }
		public required string Cpf { get; set; }
		public required string Uf { get; set; }
		public required string Celular { get; set; }
	}
}
