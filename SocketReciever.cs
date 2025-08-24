using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using System.Collections;

/// <summary>
/// Runs indefinitely, communicating with the Python server.
/// </summary>
public class SocketReciever : MonoBehaviour
{
    [SerializeField] private string host = "127.0.0.1";
    [SerializeField] private int port = 5005;
    [SerializeField] private float sendInterval = 0.1f;

    private TcpClient client;
    private NetworkStream stream;
    private StreamReader reader;
    private StreamWriter writer;
    public static String Desicion;

    private void Start()
    {
        StartCoroutine(CommunicationLoop());
    }

    private IEnumerator CommunicationLoop()
    {
        Connect();

        while (true)
        {
            if (stream.DataAvailable)
            {
                string line = reader.ReadLine();
                if (float.TryParse(line, out float val))
                {
                    if(val == 1)
                    {
                        Desicion = "Left";
                        Debug.Log("Left");
                    }
                    else
                    {
                        Desicion = "Right";
                        Debug.Log("right");
                    }

                }
            }

            if (Apple.correct != 2)
            {
                writer.WriteLine(Apple.positionFactor.ToString());
                writer.Flush();
                Debug.Log($"[UnitySockets] Sent Apple.positionFactor: {Apple.positionFactor}");
                Apple.correct = 2;

            }

            yield return new WaitForSeconds(sendInterval);
        }
    }

    private void Connect()
    {
        client = new TcpClient(host, port);
        stream = client.GetStream();
        reader = new StreamReader(stream);
        writer = new StreamWriter(stream) { AutoFlush = true };
        Debug.Log("[UnitySockets] Connected to Python server");
    }

    private void OnApplicationQuit()
    {
        writer?.Close();
        reader?.Close();
        stream?.Close();
        client?.Close();
        Debug.Log("[UnitySockets] Closed connection to Python");
    }
}