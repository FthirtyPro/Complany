using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public Animator ani;


   void Start()
    {
        ani = this.GetComponent<Animator>();
    }
    public void OnAttackButton(bool isPress,PosType posType) //传进来是否点击，还有个是技能位置，判断哪个被点击了
    {
        if(posType == PosType.Basic)
        {
            if(isPress)
            ani.SetTrigger("Attack");
        }
        else
        {
            if(isPress)
            {
                ani.SetBool("Skill" + (int)posType, true);

            }
            else
            {
                ani.SetBool("Skill" + (int)posType, false);
            }
        }
      
     
    }
}
