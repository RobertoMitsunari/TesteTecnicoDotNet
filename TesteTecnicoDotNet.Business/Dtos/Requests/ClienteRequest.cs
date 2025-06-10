namespace TesteTecnicoDotNet.Business.Dtos.Requests
{
    public class ClienteRequest
    {
		public required string Nome { get; set; }
		public required string Cpf { get; set; }
		public required string Uf { get; set; }
		public required string Celular { get; set; }
	}
}
