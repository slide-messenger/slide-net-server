// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Threading;
using MyMessenger;

int MessageId = 0;
string? Username = "";

/*
 * Асинхронный метод (async) - метод, который может выполняться в фоне 
 * и не париться по поводу других задач.
 * Сам вызов асинхронного метода не заставляет ждать, пока он завершится.
 * Если вам необходимо получить результат такого метода, то используйте await.
 */

// Фоновое бесконечное обновление сообщений
async void GetNewMessages()
{
    while (true)
    {
        Message? msg = await MessengerClientAPI.GetMessage(MessageId);
        while (msg != null)
        {
            Console.WriteLine(msg);
            ++MessageId;
            msg = await MessengerClientAPI.GetMessage(MessageId);
        }
    }
}
Console.WriteLine("Клиент запущен");

MessageId = 0;
Console.Write("Введите ваше имя пользователя: ");
Username = Console.ReadLine();
if (Username == null)
{
    Console.WriteLine("Пустое имя пользователя");
    return;
}
Console.WriteLine("Сообщения глобального чата");
GetNewMessages();
// Обмен сообщениями
string? msgText = "";
while (msgText != "exit")
{
    msgText = Console.ReadLine();
    if (msgText != null && msgText.Length > 0)
    {
        Message msg = new(Username, msgText, DateTime.UtcNow);
        string? res = await MessengerClientAPI.SendMessage(msg);
        if (res != null && res.Length > 0)
        {
            Console.WriteLine($"<Server>: {res}");
        }
    }
}


