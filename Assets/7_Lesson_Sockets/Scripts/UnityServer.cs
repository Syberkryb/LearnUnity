using UnityEngine;

namespace GameServer
{
    public class UnityServer : MonoBehaviour
    {
        private Server _server;

        void Start()
        {
            _server = new Server();
            Debug.Log("Server started");
        }

        void OnApplicationQuit()
        {
            _server.TCPListener.Stop();
            Debug.Log("Server stopped");
        }
    }
}