using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {


    public GameObject damageEffectPrefab;
    public int hp = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //受到攻击调用的方法
    //0受到多少伤害
    //1后退的距离
    //2 浮空高度
    //3 出血特效
    void TakeDamage(string args)
    {
        if (hp < 0)
            return;


        string[] proArray = args.Split(',');
        int damage = int.Parse(proArray[0]);
        hp -= damage;
        //播放受到攻击的动画
        animation.Play("takedamage");

       //浮空和后退
        float backDis = float.Parse(proArray[1]);
        float jumpDis = float.Parse(proArray[2]);
        iTween.MoveBy(this.gameObject, transform.InverseTransformDirection(TranscriptManager._instance.Player.transform.forward) * backDis
            + Vector3.up 
            * jumpDis, 0.3f);

        //出血特效

        GameObject.Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);

        if(hp<= 0)
        {
            Dead();
        }


    }

    void Dead()
    {

    }
}
