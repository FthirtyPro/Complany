using UnityEngine;
using System.Collections;

public class Task  {

    public enum TaskType
    {
        Main,
        Reward,
        Daily

    }

    public enum TaskPress
    {
        NoStart,
        Accept,
        Complete,
        Reward
    }

    private int _id;
    private int _coin;

    private string _name;
    private string _des;
    private string _icon;
    private int _diamond;
    TaskPress _taskpress;
    private TaskType _taskType;
    private string _talkNpc;
    private int _idNpc;
    private int _idTranscript;

 

    public TaskType TaskType1
    {
        get { return _taskType; }
        set { _taskType = value; }
    }

    public string Name
    {
        get { return  _name; }
        set { _name = value; }
    }

    public string Des
    {
        get { return _des; }
        set { _des = value; }
    }

    public string Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }


    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }

    public int Diamond
    {
        get { return _diamond; }
        set { _diamond = value; }
    }


    public TaskPress TaskPress1
    {
        get { return _taskpress; }
        set { _taskpress = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public int IdNpc
    {
        get { return _idNpc; }
        set { _idNpc = value; }
    }

    public int IdTranscript
    {
        get { return _idTranscript; }
        set { _idTranscript = value; }
    }

    public string TalkNpc
    {
        get {
           
            return _talkNpc; }
       
        set { _talkNpc = value; }
    }
}
