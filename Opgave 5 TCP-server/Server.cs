using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Opgave_5_TCP_server
{
    class Server
    {
        public static void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 4646;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");



                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    Stream ns = client.GetStream();

                    StreamReader sr = new StreamReader(ns);
                    StreamWriter sw = new StreamWriter(ns);
                    sw.AutoFlush = true;

                    string message = sr.ReadLine();
                    //string answer = "";

                    Console.WriteLine(value: "Client: " + message);
                    // answer = message.ToUpper();
                    // sw.WriteLine(answer);
                    
                    // message = sr.ReadLine();

                    if (message.Equals("GetAll"))
                    {
                        sw.WriteLine("GetAll");
                        sw.WriteLine(JsonConvert.SerializeObject(BeerList).ToString());
                    }
                    
                    else if (message.Equals("GetById"))
                    {
                        sw.WriteLine("GetById");
                        string ID = sr.ReadLine();
                        int Variabel = Int32.Parse(ID);
                        sw.WriteLine(JsonConvert.SerializeObject(BeerList.Find(BeerList => BeerList.Id == Variabel)));
                    }
                    
                    else if (message.Equals("Save"))
                    {
                        sw.WriteLine("Save");
                        sw.WriteLine("Skriv Elementer");
                        string BeerVariabel = sr.ReadLine();

                        BeerList.Add(JsonConvert.DeserializeObject<Beer>(BeerVariabel));
                    }
               
                    else 
                    {
                        sw.WriteLine("affald");
                    }


                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private static readonly List<Beer> BeerList = new List<Beer>()
        {
            new Beer() {Id = 1, Name = "jajj", Price = 1, Abv = 2}
        };
    }
}
