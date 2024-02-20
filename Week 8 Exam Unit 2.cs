﻿using HTTPUtils;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using static SetupVariables;
using System.Text.Json;
using static TaskFunctions;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response setupReponse = SetupResponse();
string taskID = "aAaa23"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)


//#### FIRST TASK 
// Fetch the details of the task from the server.

Response task1Response = TaskResponse(taskID);
Task? task1 = null;
if (task1Response.content != null)
{
    task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
}
Console.WriteLine($"Task #1: {Colors.Red}{ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\n{ANSICodes.Reset}");
Console.WriteLine($"Fahrenheit to Conver: {Colors.Red}{task1.parameters}{ANSICodes.Reset}");









//#### TASK

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}