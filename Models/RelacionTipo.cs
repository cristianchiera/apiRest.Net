using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestEjemplo.Models
{
    [Table("relacion_tipo")]
    public class RelacionTipo
    {

        [Column("relacion_tipo_id")]
        public int relacion_tipo_id { get; set; }

        [Column("descripcion")]
        public string? descripcion { get; set; }
    }
}