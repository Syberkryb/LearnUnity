using System.Net.Sockets;
using UnityEngine;

namespace GameClient
{
    public class UnityClient : MonoBehaviour
    {
        public string Connection = "127.0.0.1";
        private Client _client;

        void Start()
        {
            _client = new Client(Connection, 8052);
        }

        internal void Send(byte[] bytes)
        {
            try
            {
                _client.Send(bytes);
            }
            catch (SocketException socketException)
            {
                Debug.Log("Socket exception: " + socketException);
            }
        }
    }
}