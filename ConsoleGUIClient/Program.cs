// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using MyMessenger;
using Terminal.Gui;

List<Message> messages = new();
MessengerClientAPI api = new();

MenuBar menu;
Window winMain;
Window winMessages;
Label labelUser;
TextField fieldUsername;
Label labelMessage;
TextField fieldMessage;
Button btnSend;

Application.Init();
// Верхнеуровневый компонент
var top = Application.Top;

// Компонент меню
menu = new MenuBar(new MenuBarItem[]
{
    new MenuBarItem("_App", new MenuItem[]
    {
        new MenuItem("_Quit", "Close the app", Application.RequestStop),
    }),
});
top.Add(menu);

// Компонент главной формы
winMain = new Window()
{
    Title = "DotChat",
    // Позиция начала окна
    X = 0,
    Y = 1, //< Место под меню
           // Авто растягивание по размерам терминала
    Width = Dim.Fill(),
    Height = Dim.Fill()
};
top.Add(winMain);

// Компонент сообщений
winMessages = new Window()
{
    X = 0,
    Y = 0,
    Width = winMain.Width,
    Height = winMain.Height - 2,
};
winMain.Add(winMessages);

// Текст "Пользователь"
labelUser = new Label()
{
    X = 0,
    Y = Pos.Bottom(winMain) - 5,
    Width = 15,
    Height = 1,
    Text = "Username:",
};
winMain.Add(labelUser);

// Поле ввода имени пользователя
fieldUsername = new TextField()
{
    X = 15,
    Y = Pos.Bottom(winMain) - 5,
    Width = winMain.Width - 14,
    Height = 1,
};
winMain.Add(fieldUsername);

// Текст "Сообщение"
labelMessage = new Label()
{
    X = 0,
    Y = Pos.Bottom(winMain) - 4,
    Width = 15,
    Height = 1,
    Text = "Message:",
};
winMain.Add(labelMessage);

// Поле ввода сообщения
fieldMessage = new TextField()
{
    X = 15,
    Y = Pos.Bottom(winMain) - 4,
    Width = winMain.Width - 14,
    Height = 1,
};
winMain.Add(fieldMessage);

// Кнопка отправки
btnSend = new Button()
{
    X = Pos.Right(winMain) - 10 - 5,
    Y = Pos.Bottom(winMain) - 4,
    Width = 10,
    Height = 1,
    Text = "  Send  ",
};
winMain.Add(btnSend);

// Обработка клика по кнопке
btnSend.Clicked += OnBtnSendClick;

// Запуск цикла проверки обновлений сообщений
var updateLoop = new System.Timers.Timer
{
    Interval = 1000
};
int MessageID = 0;
updateLoop.Elapsed += (sender, eventArgs) =>
{
    Message msg = API.GetMessage(MessageID);
    while (msg != null)
    {
        messages.Add(msg);
        UpdateMessages();
        MessageID++;
        msg = API.GetMessage(MessageID);
    }
};
updateLoop.Start();

Application.Run();
Console.Clear();
