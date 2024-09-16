using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWork.UI.Administracion.AppMobile.Services
{
    public interface INavigationService
    {
        Task GotoAsync(string url);
        Task GotoAsync(string url,IDictionary<string,Object> parametters);
    }
}
