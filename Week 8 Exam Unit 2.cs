using HTTPUtils;
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
Response task1Response = TaskResponse(taskID);

Task? task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"Task #1: {Colors.Blue}{ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\n{ANSICodes.Reset}");
Console.WriteLine($"Fahrenheit to Convert: {Colors.Blue}{task1.parameters}{ANSICodes.Reset}");

double fahrenheit = double.Parse(task1.parameters);
double celsius = (fahrenheit - 32) * 5 / 9;
celsius = Math.Round(celsius, 2);
string task1ResponseString = celsius.ToString("0.00");

Console.WriteLine($"Temperature in Celsius: {Colors.Blue}{celsius}{ANSICodes.Reset}\n");
Response task1SubmitResponse = SubmitReponse(taskID, task1ResponseString);
Console.WriteLine($"Answer: {Colors.Green}{task1SubmitResponse}{ANSICodes.Reset}");

TaskReponseChecker(task1SubmitResponse);

//#### SECOND TASK 
taskID = "kuTw53L";
Response task2Response = TaskResponse(taskID);
Task? task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"\nTask #2: {Colors.Yellow}{ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\n{ANSICodes.Reset}");
Console.WriteLine($"Numbers in List: {Colors.Yellow}{task2.parameters}{ANSICodes.Reset}");

int[] numberList = task2.parameters.Split(',').Select(int.Parse).ToArray();
string task2Answer = "";

static bool isPrimeNumber(int number)
{
    if (number <= 1)
    {
        return false;
    }
    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

foreach (int number in numberList)
{
    if (isPrimeNumber(number))
    {
        task2Answer += number + ",";
    }
}

task2Answer = task2Answer.TrimEnd(',');
Console.WriteLine($"Prime Numbers In List: {Colors.Yellow}{task2Answer}{ANSICodes.Reset}\n");

int[] sortedNumbers = task2Answer.Split(',')
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .Select(int.Parse)
                                .OrderBy(n => n)
                                .ToArray();
task2Answer = string.Join(",", sortedNumbers);

Response task2SubmitResponse = SubmitReponse(taskID, task2Answer);
Console.WriteLine($"Answer: {Colors.Green}{task2SubmitResponse}{ANSICodes.Reset}");

TaskReponseChecker(task2SubmitResponse);

//#### THIRD TASK 
taskID = "psu31_4";
Response task3Response = TaskResponse(taskID);
Task? task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"\nTask #3: {Colors.Magenta}{ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\n{ANSICodes.Reset}");
Console.WriteLine($"Numbers in List: {Colors.Magenta}{task3.parameters}{ANSICodes.Reset}");

int[] numbers = task3.parameters.Split(',').Select(int.Parse).ToArray();
int sum = numbers.Sum();
string task3Answer = sum.ToString();
Console.WriteLine($"Sum of Numbers: {Colors.Magenta}{sum}{ANSICodes.Reset}\n");

Response task3SubmitResponse = SubmitReponse(taskID, task3Answer);
Console.WriteLine($"Answer: {Colors.Green}{task3SubmitResponse}{ANSICodes.Reset}");

TaskReponseChecker(task3SubmitResponse);

//#### FOURTH TASK 
taskID = "rEu25ZX";















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