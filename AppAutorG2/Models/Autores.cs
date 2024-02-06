using System;
using SQLite;
namespace AppAutorG2.Models
{

	[Table("Autores")]
	public class Autores
	{

        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nombres { get; set; }

        [MaxLength(255)]
        public string Pais { get; set; }

        public DateTime FechaNac { get; set; }

        [Unique]
        public string Telefono { get; set; }


        public Autores()
		{
		}
	}
}

