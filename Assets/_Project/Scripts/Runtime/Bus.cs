using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Bus 
{
    public event Action<object, string> Message;
    public event Action<object, string> error;


    public void Send(object sender, string messsage)
    {
        Message?.Invoke(sender, messsage);
    }
}


public class Subscriber
{
    public Subscriber(Bus bus)
    {
        bus.Message += ( sender, message ) => {
            Console.WriteLine($"Subscriber received message from {sender}: {message}");
        };

    }
}

public class Publisher
{
    public Publisher(Bus bus)
    {
        bus.Send(this, "Hello from Publisher!");
    }

}

public class Program
{
    public static void Main( string[] args )
    {
            Bus messageBus = new Bus();

        Subscriber subscriber = new Subscriber(messageBus);
        Publisher publisher = new Publisher(messageBus);

    }
}