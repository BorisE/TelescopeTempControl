﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Diagnostics;

namespace TelescopeTempControl
{
    
    public class SocketServerClass
    {
        /// <summary>
        /// Server parameters
        /// </summary>
        IPAddress serverIP=IPAddress.Any;
        public Int32 serverPort=1054;

        /// <summary>
        /// Main socket listener
        /// </summary>
        public Socket listenerSocket;

        /// <summary>
        /// Client list
        /// </summary>
        public List<ClientManager> clientsList = new List<ClientManager>();

        /// <summary>
        /// Back link to form
        /// </summary>
        public MainForm ParentMainForm;

        public DateTime LastTimeDataRead;


        /// <summary>
        /// command buffer for mode when data is receiving from socket
        /// </summary>
        public string SocketServerCommandBuffer = "";
        public UInt32 MAX_BUFFER_LEN = 0; //would be synced with this value in hardware

        /// <summary>
        /// Conctructor
        /// </summary>
        public SocketServerClass(MainForm MF)
        {
            ParentMainForm=MF;
        }

        /// <summary>
        /// Start server listener.
        /// After receiving incoming connection - run initClientConnection
        /// </summary>
        public void StartListenSocket()
        {
            try
            {
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.Bind(new IPEndPoint(serverIP, serverPort));
                listenerSocket.Listen(200);

                while (true)
                {
                    // Программа приостановлена. Ожидаем входящего соединения
                    Socket handler = listenerSocket.Accept();

                    //Входящее соединение необходимо обработать
                    initClientConnection(handler);
                }
            }
            catch (Exception Ex)
            {
                Logging.AddLog("Server connection errror [" + Ex.Message + "]", 0, Highlight.Error);
            }
        }

        /// <summary>
        /// Stop socket
        /// </summary>
        public void StopListenSocket()
        {
            listenerSocket.Shutdown(SocketShutdown.Send);
        }

        /// <summary>
        /// This handler is run when new client init connection
        /// It create new object ClientManager for this client and pass control to it
        /// </summary>
        /// <param name="curSocket">Server</param>
        public void initClientConnection(Socket curSocket)
        {
            Logging.AddLog("Connection from " + curSocket.RemoteEndPoint + " accepted",LogLevel.Activity);

            //Создаем объект для обработки клиента
            ClientManager NewClient=new ClientManager(this);
            
            //Добавляем его в список
            clientsList.Add(NewClient);
            
            //Передаем ему управление
            NewClient.CreateNewClientManager(curSocket);

            //Отображаем кол-во соединений в форме
            //ParentMainForm.toolStripStatus_Connection.Text = "CONNECTIONS: " + clientsList.Count;
        }

        public int OpenedConnectionsCount()
        {
            return clientsList.Count;
        }


        /// <summary>
        /// Connect to another socket server
        /// </summary>
        /// <param name="ipAddr">server addres</param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        public void MakeClientConnectionToServer(IPAddress ipAddr, Int32 port, string message)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];
            
            // Устанавливаем удаленную точку для сокета
            //IPAddress ipAddr = Dns.GetHostEntry("localhost").AddressList[0];
            //IPAddress localAddr = IPAddress.Parse("127.0.0.1"); 
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Соединяем сокет с удаленной точкой
                sender.Connect(ipEndPoint);
                Logging.AddLog("Connected to " + sender.RemoteEndPoint.ToString(), LogLevel.Activity);
                byte[] msg = Encoding.UTF8.GetBytes(message);

                // Отправляем данные через сокет
                int bytesSent = sender.Send(msg);

                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);

                string responseMess = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                Logging.AddLog("Response from server: " + responseMess,LogLevel.Debug);

                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception Ex)
            {
                StackTrace st = new StackTrace(Ex, true);
                StackFrame[] frames = st.GetFrames();
                string messstr = "";

                // Iterate over the frames extracting the information you need
                foreach (StackFrame frame in frames)
                {
                    messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                }

                string FullMessage = "MakeClientConnectionToServer socket connection failed!" + Environment.NewLine;
                FullMessage += Environment.NewLine + Environment.NewLine + "Debug information:" + Environment.NewLine + "IOException source: " + Ex.Data + " " + Ex.Message
                        + Environment.NewLine + Environment.NewLine + messstr;
                //MessageBox.Show(this, FullMessage, "Invalid value", MessageBoxButtons.OK);

                Logging.AddLog("MakeClientConnectionToServer socket connection failed! " + Ex.Message, LogLevel.Important, Highlight.Error);
                Logging.AddLog(FullMessage,LogLevel.Debug,Highlight.Error);
            }
        }

    }

    /// <summary>
    /// Class for every client management
    /// </summary>
    public class ClientManager
    {
        /// <summary>
        /// Client socket
        /// </summary>
        Socket ClientSocket;

        /// <summary>
        /// Client thread
        /// </summary>
        Thread curThread;

        /// <summary>
        /// Back link to socket server
        /// </summary>
        public SocketServerClass ParentSocketServer;
        public MainForm ParentMainFormLink;

        private byte[] welcomeMsg = Encoding.UTF8.GetBytes("Connected to TelescopeTempControl\r\n");
        const string STOP_MESSAGE = "TheEnd";

        // Буфер для входящих данных
        byte[] incomingBuffer = new byte[1024];

        public ClientManager(SocketServerClass SockSrv)
        {
            ParentSocketServer = SockSrv;
            ParentMainFormLink = ParentSocketServer.ParentMainForm;
        }

        public void CreateNewClientManager(Socket NewClient)
        {
            this.ClientSocket = NewClient;
            curThread = new Thread(startClientThread);
            curThread.Start();
        }

        /// <summary>
        /// Start unique thread for every client
        /// </summary>
        public void startClientThread()
        {

            //Отправляем приветственное сообщение
            ClientSocket.Send(welcomeMsg);

            try
            {
                while (true)
                {
                    // Получаем ответ от клиента
                    int bytesRec = ClientSocket.Receive(incomingBuffer);

                    if (!(bytesRec == 2 && incomingBuffer[0] == 13 && incomingBuffer[1] == 10)) // \r\n  i.e.  \r = 0D, 13  \n = 0A, 10
                    {
                        //Convert message from UTF8
                        string incomingMess = Encoding.UTF8.GetString(incomingBuffer, 0, bytesRec);
                        Logging.AddLog("Message from сlient [" + ClientSocket.RemoteEndPoint + "]: " + incomingMess, LogLevel.Debug);

                        //Interpret incoming message and run appropriate command
                        string cmdMess = SocketCommandInterpretator(incomingMess);

                        //If it was STOP command, break (all other neccessary stuff was made in CommandInterpretator
                        if (cmdMess == STOP_MESSAGE) {break; }

                        //Output return string
                        byte[] msg2 = Encoding.UTF8.GetBytes(cmdMess + "\r\n");
                        ClientSocket.Send(msg2);
                    }
                }
            }
            catch (Exception ex) 
            {
                Logging.AddLog("Socket client [" + ClientSocket.RemoteEndPoint + "] exception: " + ex.ToString(), LogLevel.Important, Highlight.Error);
            }


            //Отображаем кол-во соединений в форме
            //ParentMainForm.toolStripStatus_Connection.Text = "CONNECTION: " + clientsList.Count;
        }

        /// <summary>
        /// Stop client socket and thread
        /// </summary>
        public void StopClientThread()
        {
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();

            //curThread.Abort(); // НЕ НУЖНО! Поток и так завершиться после BREAK в цикле
        }

        public string SendCommandToClient(string cmd)
        {
            //not working yet
            byte[] msg = Encoding.UTF8.GetBytes(cmd + "\r\n");
            Logging.AddLog("Send command to сlient [" + ClientSocket.RemoteEndPoint + "]: " + cmd, LogLevel.Activity);
            ClientSocket.Send(msg);

            // Получаем ответ от клиента
            int bytesRec = ClientSocket.Receive(incomingBuffer);

            if (!(bytesRec == 2 && incomingBuffer[0] == 13 && incomingBuffer[1] == 10))
            {
                string incomingMess = Encoding.UTF8.GetString(incomingBuffer, 0, bytesRec);
                Logging.AddLog("Response from сlient [" + ClientSocket.RemoteEndPoint + "]: " + incomingMess, LogLevel.Activity);
            }

            return cmd;
        }


        /// <summary>
        /// SocketCommandInterpretator
        /// </summary>
        /// <param name="cmd">command</param>
        /// <returns>output message</returns>
        public string SocketCommandInterpretator(string cmd)
        {
            string msg = "";

            //Trim etc command string
            cmd = cmd.Replace("\n", String.Empty).Replace("\r", String.Empty);
            cmd = cmd.Replace("\t", String.Empty);
            cmd = cmd.Trim();

            //if it is sensor value - add ir to buffer
            if (cmd.StartsWith("[!"))
            {
                ParentSocketServer.SocketServerCommandBuffer += cmd + Environment.NewLine;

                //mark last read data
                ParentSocketServer.LastTimeDataRead= DateTime.Now;

                //return message
                msg = "OK";

                //cut buffer if it too large
                if (ParentSocketServer.SocketServerCommandBuffer.Length > ParentSocketServer.MAX_BUFFER_LEN)
                {
                    ParentSocketServer.SocketServerCommandBuffer = ParentSocketServer.SocketServerCommandBuffer.Substring((Int16)(ParentSocketServer.SocketServerCommandBuffer.Length - ParentSocketServer.MAX_BUFFER_LEN));
                    Logging.AddLog("SerialBuffer was cut to " + ParentSocketServer.MAX_BUFFER_LEN, LogLevel.Debug);
                }

            }
            else
            //else - try to parse as a command
            {
                switch (cmd)
                {
                    case STOP_MESSAGE:
                        // Освобождаем сокет
                        Logging.AddLog("Client [" + ClientSocket.RemoteEndPoint + "] has ended connection", LogLevel.Activity);
                        StopClientThread();
                        msg = STOP_MESSAGE;
                        break;
                    default:
                        string cmd_output = "";

                        //parse given command
                        if (ParentMainFormLink.Hardware.CommandParser.ParseSingleCommand(cmd, out cmd_output))
                        {
                            Logging.AddLog("Client [" + ClientSocket.RemoteEndPoint + "]: " + "command [" + cmd + "] successfully run. Output: " + cmd_output, LogLevel.Activity, Highlight.Normal);
                            msg = "Command [" + cmd + "] was run. Output: " + cmd_output; //for debug
                            msg = cmd_output;
                        }
                        else
                        {
                            Logging.AddLog("Client [" + ClientSocket.RemoteEndPoint + "]: " + "Unknown command [" + cmd + "]", LogLevel.Activity, Highlight.Error);
                            msg = "Unknown command [" + cmd + "]";
                        }
                        break;
                }
            }

            return msg;
        }
    
    
    }
}
