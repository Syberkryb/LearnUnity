using System;
using System.Net;
using System.Net.Sockets;
using Lib;
using UnityEngine;

namespace GameClient
{
    public class Client
    {
        private const int _dataBufferSize = 4096;
        private readonly TcpClient _socket;
        private NetworkStream _stream;
        private readonly byte[] _recieveBuffer;
        public AuthInfo Account;

        public Client(string ip, int port)
        {
            _socket = new TcpClient
            {
                ReceiveBufferSize = _dataBufferSize,
                SendBufferSize = _dataBufferSize
            };
            _recieveBuffer = new byte[_dataBufferSize];
            Debug.Log("Connecting to : " + IPAddress.Parse(ip));
            _socket.BeginConnect(IPAddress.Parse(ip), port, ConnectCB, null);
        }

        public void Send(byte[] bytes)
        {
            if (_stream.CanWrite)
            {
                _stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void ConnectCB(IAsyncResult ar)
        {
            _socket.EndConnect(ar);
            if (!_socket.Connected)
            {
                return;
            }
            _stream = _socket.GetStream();
#if UNITY_EDITOR
            Account = new AuthInfo() { Id = 0, Username = "Haps", Password = "Snaps" };
#else
            System.Random rnd = new System.Random();
            Account = new AuthInfo() { Id = 0, Username = "Snaps_" +rnd.Next(1, 1000) , Password = "Haps"};
#endif

            Send(Helpers.Serialize<AuthInfo>(Account));
            _stream.BeginRead(_recieveBuffer, 0, _dataBufferSize, RecieveCB, null);
        }

        private void RecieveCB(IAsyncResult ar)
        {
            try
            {
                int _recievedLength = _stream.EndRead(ar);
                if (_recievedLength > 0)
                {
                    byte[] data = new byte[_recievedLength];
                    Array.Copy(_recieveBuffer, data, _recievedLength);

                    object obj = Helpers.Deserialize<object>(data);
                    if (obj is AuthInfo)
                    {
                        Process((AuthInfo)obj);
                    }else if (obj is Move)
                    {
                        Process((Move)obj);
                    }

                    _stream.BeginRead(_recieveBuffer, 0, _dataBufferSize, RecieveCB, null);
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception e)
            {
                Disconnect();
                Debug.Log("Error recieved TCP Data " + e.ToString());
            }
        }

        private void Process(AuthInfo auth)
        {
            Account.Id = auth.Id;
            Debug.Log("Authinfo recieved " + auth.Id);
        }

        private void Process(Move move)
        {
            ExecuteOnMainthread.RunOnMainThread.Enqueue(() =>
            {
                //What to do
            });
        }

        private void Disconnect()
        {
            Debug.Log("Disconnected");
            _stream.Close();
            _socket.Close();
        }
    }
}