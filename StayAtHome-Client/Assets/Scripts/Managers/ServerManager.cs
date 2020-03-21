using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class ServerManager : MonoBehaviour
{

    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    void Start()
    {
        Connect();
    }

    void Update()
    {

    }

    private void Connect()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(Listen));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void Listen()
    {
        try
        {
            Console.WriteLine("Listen");
            socketConnection = new TcpClient("localhost", 80);
            byte[] bytes = new byte[1024];
            while (true)
            {
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var data = new byte[length];
                        Array.Copy(bytes, 0, data, 0, length);
                        string serverMessage = Encoding.ASCII.GetString(data);
                        Debug.Log("server message received as: " + serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void Send(object data)
    {
        if(socketConnection != null)
        {
            return;
        }
        try
        {
            NetworkStream stream = socketConnection.GetStream();
            if(stream.CanWrite)
            {
                string json = JsonUtility.ToJson(data);

                byte[] msgAsByteArray = Encoding.ASCII.GetBytes(json);

                stream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                Debug.Log("Client sent his message - should be received by server");
            }
        }
        catch(SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

}
