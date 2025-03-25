using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

// 네트워크 코드에서는 gameobject 건들지 말것!

public class Packet
{
    public string code;
    public string user_id;
    public string user_password;

}

public class Loginclass : Packet
{

}

public class SignUpclass : Packet
{
    public string user_name;
    public string user_email;


}

public class Chatclass : Packet
{
    public string chat;

}


public class NetworkManaget : MonoBehaviour
{
    private Socket serversocket;
    private IPEndPoint serverEndPoint;
    private Thread recvthread;


    public TMP_InputField idUI;
    public TMP_InputField passwordUI;

    public TMP_InputField newidUI;
    public TMP_InputField newpasswordUI;
    public TMP_InputField newnameUI;
    public TMP_InputField newemailUI;

    public TMP_InputField ChatUI;

    public Queue<Packet> data;



    void Start()
    {
        ConnectedToServer();
    }

    void RecvPacket()
    {
        while (true)
        {
            byte[] lengthBuffer = new byte[2];

            int recvLength = serversocket.Receive(lengthBuffer, 2, SocketFlags.None);

            ushort length = BitConverter.ToUInt16(lengthBuffer, 0);

            length = (ushort)IPAddress.NetworkToHostOrder((short)length);

            byte[] recvBuffer = new byte[4096];

            recvLength = serversocket.Receive(recvBuffer, length, SocketFlags.None);

            string jsonString = Encoding.UTF8.GetString(recvBuffer);

            Debug.Log(jsonString);
            // Parsing
            Thread.Sleep(10);

            

        }
    }

    void ConnectedToServer()
    {
        serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.28"), 4000);
        serversocket.Connect(serverEndPoint);
        recvthread = new Thread(new ThreadStart(RecvPacket));
        recvthread.IsBackground = true;
        recvthread.Start();

    }

    void SendPacket(string message)
    {

        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
        ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

        byte[] headerBuffer = BitConverter.GetBytes(length);

        byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];

        Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
        Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

        int SendLength = serversocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);
    }

  

    public void OnLogin()
    { 
        Loginclass packet = new Loginclass();
        packet.code = "Login";
        packet.user_id = idUI.text;
        packet.user_password = passwordUI.text;

        SendPacket(JsonUtility.ToJson(packet));
        
    }

    public void OnSignUp()
    {
        SignUpclass packet = new SignUpclass();
        packet.code = "SignUp";
        packet.user_id = newidUI.text;
        packet.user_password = newpasswordUI.text;
        packet.user_name = newnameUI.text;
        packet.user_email = newemailUI.text;

        SendPacket(JsonUtility.ToJson(packet));


    }

    public void OnChat()
    { 
        Chatclass packet = new Chatclass();
        Loginclass loginclass = new Loginclass();
        string inputChat;
        inputChat = ChatUI.text;
        string jsonString = inputChat;
        packet.code = "Chat";
        packet.chat = jsonString;  


        ChatSendPacket(JsonUtility.ToJson(packet));
    }

    void ChatSendPacket(string msg)
    {
        while (true)
        {
            byte[] message = Encoding.UTF8.GetBytes(msg);
            ushort length = (ushort)message.Length;

            // 길이   자료
            // [][]   [][][][][][][][]
            byte[] lengthBuffer = new byte[2];
            lengthBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)length));

            //[][][][][][][][][][]
            byte[] buffer = new byte[2 + length];

            Buffer.BlockCopy(lengthBuffer, 0, buffer, 0, 2);
            Buffer.BlockCopy(message, 0, buffer, 2, length);

            int sendLength = serversocket.Send(buffer, buffer.Length, SocketFlags.None);
        }
    }


    private void OnApplicationQuit()
    {
        if (recvthread != null)
        {
            recvthread.Abort(); // 스레드 그만하기
        }

        if (serversocket != null)
        {
            serversocket.Shutdown(SocketShutdown.Both); // 서로 끝이라고 확인 후 끊기
            serversocket.Close();
        }
    }


}
