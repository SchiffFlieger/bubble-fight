using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class StaticWriter
{

    public static int round;
	public static int damageDone;
	public static int circleCount; 
	public static int circleSum;
	public static int ringCount;
	public static int ringDamage;

    private static bool active = true;

    public static void SendNetworkMessage()
    {
        if (!active) { return; }

        var builder = new StringBuilder();
        builder.AppendLine("session:" + session);
		builder.AppendLine("round:" + round);
        builder.AppendLine("damage:" + ringDamage);
        builder.AppendLine("rings:" + ringCount);
        builder.AppendLine("damageDone:" + damageDone);
        builder.AppendLine("circleCount:" + circleCount);
        builder.AppendLine("circleSum:" + circleSum);
        builder.AppendLine("score:" + ScoreManager.GetScore());
        UnityWebRequest request = UnityWebRequest.Post("localhost:8080/test", builder.ToString());
        request.SendWebRequest();
    }


    private static System.Random random;
    private static string session;

    static StaticWriter()
    {
        StaticWriter.random = new System.Random();
        StaticWriter.session = StaticWriter.RandomString(10);
    }

    private static string RandomString(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
