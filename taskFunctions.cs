using HTTPUtils;

public class TaskFunctions
{
    public static Response SetupResponse()
    {
        return HttpUtils.instance.Get(SetupVariables.baseURL + SetupVariables.startEndpoint + SetupVariables.myPersonalID).Result;
    }

    public static Response TaskResponse(string taskID)
    {
        return HttpUtils.instance.Get(SetupVariables.baseURL + SetupVariables.taskEndpoint + SetupVariables.myPersonalID + "/" + taskID).Result;
    }
    
    public static Response SubmitReponse(string taskID, string answer)
    {
        return HttpUtils.instance.Post(SetupVariables.baseURL + SetupVariables.taskEndpoint + SetupVariables.myPersonalID + "/" + taskID, answer).Result;
    }
}