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
Console.WriteLine($"Task #1: {Colors.Blue}{ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\n{ANSICodes.Reset}");
Console.WriteLine($"Fahrenheit to Convert: {Colors.Blue}{task1.parameters}{ANSICodes.Reset}");

double fahrenheit = double.Parse(task1.parameters);
double celsius = (fahrenheit - 32) * 5 / 9;
celsius = Math.Round(celsius, 2);
string task1ResponseString = celsius.ToString();

Console.WriteLine($"Temperature in Celsius: {Colors.Blue}{celsius}{ANSICodes.Reset}\n");
Response task1SubmitResponse = SubmitReponse(taskID, task1ResponseString);
Console.WriteLine($"Answer: {Colors.Green}{task1SubmitResponse}{ANSICodes.Reset}");

TaskReponseChecker(task1SubmitResponse);










static void TaskReponseChecker(Response taskSubmitResponse)
{
    if (taskSubmitResponse.content.Contains("taskID"))
    {
        Console.WriteLine($"{Colors.Green}Task passed, no issue.{ANSICodes.Reset}");
    }
    else
    {
        Console.WriteLine($"{Colors.Red}Task failed, please try again.{ANSICodes.Reset}");
    }
}