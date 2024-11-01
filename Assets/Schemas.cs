using System;

[Serializable]
public class Void
{
}

[Serializable]
public class ErrorBody
{
    public int errorId;
    public string message;
}

[Serializable]
public class DirectionResponses
{
    public int direction;
    public bool isIdling;
}