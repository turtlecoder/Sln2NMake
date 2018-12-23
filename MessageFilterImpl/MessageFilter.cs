using System;
using System.Runtime.InteropServices;

namespace MessageFilterImpl
{
  public class MessageFilter : IOleMessageFilter
  {
    [DllImport("Ole32.dll")]
    private static extern int CoRegisterMessageFilter(IOleMessageFilter hTaskCallee, out IOleMessageFilter oldFilter);



    #region IOleMessageFilter Members

    int IOleMessageFilter.HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
    {
      return 0;
    }

    int IOleMessageFilter.RetryRejectedCall(IntPtr hTaskCallee, int dwTickCout, int dwRejectType)
    {
      if (dwRejectType==2){
        return 99;
      }
      return -1;
    }

    int IOleMessageFilter.MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
    {
      return 2;
    }

    #endregion


    public static void Register()
    {
      var newFilter = new MessageFilter() as IOleMessageFilter;
      var oldFilter = null as IOleMessageFilter;
      CoRegisterMessageFilter(newFilter, out oldFilter);
    }

    public static void Revoke()
    {
      var oldFilter = null as IOleMessageFilter;
      CoRegisterMessageFilter(null, out oldFilter);
    }
  }
}
