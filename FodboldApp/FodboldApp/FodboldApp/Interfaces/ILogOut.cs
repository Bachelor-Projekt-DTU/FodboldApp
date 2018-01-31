using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FodboldApp.Interfaces
{
    public interface ILogOut
    {
        Task LogOutGoogleAsync();
        void LogOutFB();
    }
}
