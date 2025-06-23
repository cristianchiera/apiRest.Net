using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestEjemplo.Models
{
    [Table("sujeto_actividad_id")]
    public class SujetoActividad
    {
        [Column("apellido")]
        public string? apellido { get; set; }
        [Column("dni")]
        public int? dni { get; set; }
        [Column("sujeto_actividad_id")]
        public int? sujeto_actividad_id { get; set; }
        [Column("cuil")]
        public string? cuil { get; set; }
        [Column("telefono")]
        public string? telefono { get; set; }
        [Column("email")]
        public string? email { get; set; }
        [Column("tipo_persona_id")]
        public string? tipo_persona_id { get; set; }
        [Column("relacion_tipo_id")]
        public int relacion_tipo_id { get; set; }
        [Column("razon_social")]
        public string? razon_social { get; set; }
        [Column("domicilio_real")]
        public string? domicilio_real { get; set; }
        [Column("departamento_id")]
        public string? departamento_id { get; set; }
        [Column("domicilio_comercial")]
        public string? domicilio_comercial { get; set; }
        [Column("registro_municipal_id")]
        public string? registro_municipal_id { get; set; }
        [Column("registro_afip_id")]
        public string? registro_afip_id { get; set; }
        [Column("registro_atm_id")]
        public string? registro_atm_id { get; set; }
        [Column("sujeto_access_id")]
        public string? sujeto_access_id { get; set; }
        [Column("operaciones_id")]
        public string? operaciones_id { get; set; }
        [Column("isactive")]
        public bool? isactive { get; set; }
        [Column("id")]
        public int? id { get; set; }
        [Column("departamento_comercial_id")]
        public int? departamento_comercial_id { get; set; }
        [Column("nombres")]
        public string? nombres { get; set; }

        
    }
}