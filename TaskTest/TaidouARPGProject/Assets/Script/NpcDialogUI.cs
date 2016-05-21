using UnityEngine;
using System.Collections;

public class NpcDialogUI : MonoBehaviour {
    public static NpcDialogUI _instance;
    private TweenPosition tween;
    private UILabel NpcTalkLabel;
    private UIButton acceptButton;

    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
      
        tween = this.GetComponent<TweenPosition>();
        NpcTalkLabel = transform.Find("NpcCotent").GetComponent<UILabel>();
        acceptButton = transform.Find("acceptButton").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "OnAccept");
        acceptButton.onClick.Add(ed1);

    }

    public void Show(string npcTalk)
    {
        NpcTalkLabel.text = npcTalk;
        tween.PlayForward();


    }

   

    void OnAccept()//接受任务后，隐藏对话框
    {
        TaskManager._instance.OnAcceptTask();
        tween.PlayReverse();

    }

}
