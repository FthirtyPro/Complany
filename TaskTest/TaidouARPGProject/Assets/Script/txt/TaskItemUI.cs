using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour {

    private UISprite taskTypeSprite;
    private UISprite iconSprite;
    private UILabel nameLabel;
    private UILabel desLabel;
    private UILabel reward1Label;
    private UISprite reward1Sprite;
    private UISprite reward2Sprite;
    private UILabel reward2Label;

    private UIButton combatButton;
    private UILabel combatButtonLabel;
    private UIButton rewardButton;


    private Task task;
    public void Awake()
    {
        taskTypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
        iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        reward1Sprite = transform.Find("Reward1Sprite").GetComponent<UISprite>();
        reward1Label = transform.Find("Reward1Label").GetComponent<UILabel>();

        reward2Sprite = transform.Find("Reward2Sprite").GetComponent<UISprite>();
        reward2Label = transform.Find("Reward2Label").GetComponent<UILabel>();

        combatButton = transform.Find("CombatButton").GetComponent<UIButton>();
        rewardButton = transform.Find("RewardButton").GetComponent<UIButton>();
        combatButtonLabel = transform.Find("CombatButton/Label").GetComponent<UILabel>();

        EventDelegate ed1 = new EventDelegate(this, "OnCombat");
        combatButton.onClick.Add(ed1);
        
    }

    public void setTask(Task task)
    {
        this.task = task;
        switch(task.TaskType1)
        {
            case Task.TaskType.Main:
                taskTypeSprite.spriteName = "pic_主线";
                break;

            case Task.TaskType.Reward:
                taskTypeSprite.spriteName = "pic_主线";

                break;
                
            case Task.TaskType.Daily:
                taskTypeSprite.spriteName = "pic_日常";

                break;
        }

        iconSprite.spriteName = task.Icon; //把任务图标传过来
        nameLabel.text = task.Name;
        desLabel.text = task.Des;
        if(task.Coin>0 && task.Diamond>0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "X" + task.Coin;
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "X" + task.Diamond;
        }
        else if(task.Coin>0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "X" + task.Coin;
            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);


        }
        else if(task.Diamond>0)
        {
            reward1Sprite.gameObject.SetActive(false);
            reward1Label.gameObject.SetActive(false);
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "X" + task.Diamond;
        }

        switch(task.TaskPress1)
        {
            case Task.TaskPress.NoStart:
                rewardButton.gameObject.SetActive(false);
                combatButtonLabel.text = "下一步";
                break;
            case Task.TaskPress.Accept:
                rewardButton.gameObject.SetActive(false);
                combatButtonLabel.text = "战斗";
                break;
            case Task.TaskPress.Complete:
                combatButton.gameObject.SetActive(false);
                break;
        }


        

    }

    void OnCombat()
    {
        TaskUI._instance.MoveTaskUIHidden();
        TaskManager._instance.OnExcuteTask(task);
    }
}
