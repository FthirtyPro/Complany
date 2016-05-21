using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour {

    private PlayerAnimation playerAnimation;
    public PosType posType;
    public float coldTime = 4;
    private float coldTimer = 0; //表示冷却结束
    private UISprite maskSprite;

    private UIButton btn;

    void Start()
    {
       playerAnimation= TranscriptManager._instance.Player.GetComponent<PlayerAnimation>();
        if(transform.Find("Mask"))
        {
            maskSprite = transform.Find("Mask").GetComponent<UISprite>();
        }

        btn = this.GetComponent<UIButton>();
    }

    void Update()
    {
        if (maskSprite == null)
            return;
        if(coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            maskSprite.fillAmount = coldTimer / coldTime;
            if(coldTimer <= 0)
            {
                EnDisable();
            }
        }
        else
        {
            maskSprite.fillAmount = 0;
        }
    }



 void  OnPress(bool isPress)
    {
        playerAnimation.OnAttackButton(isPress, posType);
      if(isPress)
      {
          coldTimer= coldTime;
          if (maskSprite == null)
              return;
          Disable();

      }
    }


    void Disable()
 {
     this.collider.enabled = false;
 }

    void EnDisable()
    {
        this.collider.enabled = true;

    }


}
