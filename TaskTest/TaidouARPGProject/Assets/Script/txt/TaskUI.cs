using UnityEngine;
using System.Collections;

public class TaskUI : MonoBehaviour {

    public static TaskUI _instance;
    private UIGrid taskListGrid;
    private TweenPosition UITaskTween;
    private UIButton closeButton;

    public GameObject taskItemPrefab;
    void Awake()
    {
        _instance = this;
        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        UITaskTween = this.GetComponent<TweenPosition>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();

        EventDelegate ed = new EventDelegate(this, "MoveTaskUIHidden");
        closeButton.onClick.Add(ed); 


    }
    void Start()
    {
        InitTaskList();
        MoveTaskUIHidden();
    }

    void InitTaskList()
    {
        ArrayList tasklist = TaskManager._instance.GetTaskList(); //从管理器里去得到任务信息
        foreach(Task task in tasklist)
        {
            GameObject go = NGUITools.AddChild(taskListGrid.gameObject, taskItemPrefab);
            taskListGrid.AddChild(go.transform); //对添加的舞台进行排序
            TaskItemUI ui = go.GetComponent<TaskItemUI>();
            ui.setTask(task);
        }
    }

   public void MoveTaskUI()
    {
        UITaskTween.PlayForward();
    }

    public void MoveTaskUIHidden()
   {
       UITaskTween.PlayReverse();
   }
}
