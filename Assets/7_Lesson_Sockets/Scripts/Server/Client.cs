using System;
using System.Net.Sockets;
using Lib;
using UnityEngine;

namespace GameServer
{
    public class Client
    {
        public int Id;
        public string Username;
        public TcpClient Socket;

        private NetworkStream _stream;
        private byte[] _receiveBuffer;
        private readonly int _dataBuffer = 4096;

        public Client(int id)
        {
            Id = id;
        }

        public void Connect(TcpClient socket)
        {
            Socket = socket;
            Socket.ReceiveBufferSize = _dataBuffer;
            Socket.SendBufferSize = _dataBuffer;
            _stream = Socket.GetStream();
            _receiveBuffer = new byte[_dataBuffer];
            _stream.BeginRead(_receiveBuffer, 0, _dataBuffer, RecieveCB, Socket);
        }

        private void RecieveCB(IAsyncResult ar)
        {
            try
            {
                int _recievedLength = _stream.EndRead(ar);
                if (_recievedLength > 0)
                {
                    byte[] data = new byte[_recievedLength];
                    Array.Copy(_receiveBuffer, data, _recievedLength);
                    object obj = Helpers.Deserialize<object>(data);
                    if (obj is AuthInfo)
                    {
                        Process((AuthInfo)obj);
                    }
                    else if (obj is Move)
                    {
                        Process((Move)obj);
                    }

                    _stream.BeginRead(_receiveBuffer, 0, _dataBuffer, RecieveCB, null);
                }
                else
                {
                    Debug.Log("Recieved 0 data");
                    Disconnect();
                    return;
                }
            }
            catch (Exception e)
            {
                Disconnect();
                Debug.Log("Error recieved TCP Data " + e.ToString());
            }
        }

        public void Disconnect()
        {
            Socket.Close();
            Socket = null;
            _stream.Close();
            _stream = null;
            _receiveBuffer = new byte[_dataBuffer];
        }

        public void Send(byte[] bytes)
        {
            if (_stream.CanWrite)
            {
                _stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void Process(AuthInfo auth)
        {
            Username = auth.Username;

            Debug.Log("Server recieved Auth info : " + auth.Username + " from client " + Id);

        }

        private void Process(Move move)
        {
            Debug.Log("Server recieved move from client " + Id);
        }
    }
}