using FodboldApp.View;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FodboldApp.ViewModel
{
    public static class NoInternetVM
    {
        public static void IsConnected(SyncConfiguration syncConfiguration)
        {
            try
            {
                int zero = 0;
                int i = 1 / zero;
            }
            catch (Exception)
            {
                HeaderVM.SetContent(new NoInternetPage());
                Thread.Sleep(1000);
                IsConnected(syncConfiguration);
            }
        }
    }
}
