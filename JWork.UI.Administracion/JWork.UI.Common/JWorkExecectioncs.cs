using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JWork.UI.Administracion.Common
{
    public class JWorkExecectioncs : Exception
    {
        public JWorkExecectioncs()
        {
        }

        public JWorkExecectioncs(string? message) : base(message)
        {
        }

        public JWorkExecectioncs(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected JWorkExecectioncs(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
