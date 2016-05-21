using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {
    public static TaskManager _instance;
    public TextAsset taskinfoText;
    private ArrayList tasklist =new ArrayList();
    public Task currentTask;
    private autoMoveLath playerauto;
    private autoMoveLath PlayerAutoMove
    {
        get
        {
            if (playerauto == null)
            {
                playerauto = GameObject.FindGameObjectWithTag("Player").GetComponent<autoMoveLath>();
            }
            return playerauto;

        }
    }

    void Awake()
    {
        _instance = this;
        InitTask();
    }

    
    public void InitTask()
    {
        string[] taskinfoArray = taskinfoText.ToString().Split('\n');
        foreach(string str in taskinfoArray)
        {
            string[] proArray = str.Split('|');
            Task task = new Task();
            task.Id = int.Parse(proArray[0]);
            switch(proArray[1])
            {
                case"Main":
                    task.TaskType1 = Task.TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType1 = Task.TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType1 = Task.TaskType.Daily;
                    break;
            }
            task.Name = proArray[2];
            task.Icon = proArray[3];
            task.Des = proArray[4];
            task.Coin =int.Parse( proArray[5]);
            task.Diamond = int.Parse(proArray[6]);

            tasklist.Add(task);

        }

    }


    public ArrayList GetTaskList()
    {
        return tasklist;
    }

    public void OnExcuteTask( Task task)
    {
        currentTask = task;
        if(task.TaskPress1 == Task.TaskPress.NoStart)
        {
            PlayerAutoMove.SetDestination(NpcManager._instance.GetNpcById(task.Id).transform.position);

        }else if(task.TaskPress1 == Task.TaskPress.Accept)
        {
            //PlayerAutoMove.SetDestination(NpcManager._instance.tran)
            //到副本入口
        }
    }

    public void OnAcceptTask()
    {
        currentTask.TaskPress1 = Task.TaskPress.Accept;
        //寻路到副本路口；
    }

    public void OnArriveDestination()
    {
        if(currentTask.TaskPress1 == Task.TaskPress.NoStart)
        {
            //到达Npc所在
            //
            currentTask.TaskPress1 = Task.TaskPress.Accept;
           
            print(currentTask.TalkNpc);
        }


        //到达副本入口；

    }
}
