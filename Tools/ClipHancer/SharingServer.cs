using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;

namespace ClipHancer
{
    class SharingServer
    {
        byte[] data = new byte[0];
        readonly TcpListener listener;

        public SharingServer()
        {
            listener = new TcpListener(IPAddress.Any, 5120);
            try
            {
                listener.Start();
                new Thread(run).Start();
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10048)
                {
                    MessageBox.Show("Cannot share: Port already in use.");
                }
                else
                {
                    throw ex;
                }
            }
        }

        private void run()
        {
            try
            {
                while (true)
                {
                    Socket s = listener.AcceptSocket();
                    lock (this)
                    {
                        s.Send(data);
                    }
                    s.Close();
                }
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode != 10004) throw ex;
            }
        }

        internal void Share(ClipboardEntry toShare)
        {
            lock (this)
            {
                data = toShare.Serialize();
            }
        }

        internal void StopSharing()
        {
            listener.Stop();
        }
    }
}
