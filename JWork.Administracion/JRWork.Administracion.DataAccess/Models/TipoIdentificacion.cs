using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRWork.Administracion.DataAccess.Models
{
    public class TipoIdentificacion
    {
        public int TipoDocumentoId { get; set; }
        public string Sigla { get; set; } = null!;
        public string Nombre { get; set; } = null!; 
    }
}
