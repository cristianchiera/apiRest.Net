namespace ApiRestEjemplo.Models
{
    public class SujetoActividadPatchDto
    {
        public string? apellido { get; set; }
        public string? nombres { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public string? cuil { get; set; }
        public string? razon_social { get; set; }
        public string? domicilio_real { get; set; }
        public int? dni { get; set; }
        public int? sujeto_actividad_id { get; set; }
        public string? tipo_persona_id { get; set; }
        public string? departamento_id { get; set; }
        public bool? isactive { get; set; }
        // Agrega aquí el resto de los campos de tu modelo, todos como nullable
    }
}