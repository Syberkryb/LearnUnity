using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace GameServer
{
    public class Server
    {
        public int Port { get; private set; }
        public TcpListener TCPListener;
        public List<Client> Clients;

        public Server(int port = 8052)
        {
            Port = port;
            TCPListener = new TcpListener(IPAddress.Any, Port);
            Clients = new List<Client>();
            TCPListener.Start();
            TCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPAcceptCB), null);
        }

        private void TCPAcceptCB(IAsyncResult ar)
        {
            TcpClient client = TCPListener.EndAcceptTcpClient(ar);
            TCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPAcceptCB), null);
            Client c = new Client(Clients.Count+1);
            Debug.Log("Client connected " + c.Id);
            c.Connect(client);
            Clients.Add(c);
        }
    }
}