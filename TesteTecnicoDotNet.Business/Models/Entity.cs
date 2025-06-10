using System.Text.Json.Serialization;

namespace TesteTecnicoDotNet.Business.Models
{
	public class Entity
	{
		[JsonIgnore]
		public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
	}
}
