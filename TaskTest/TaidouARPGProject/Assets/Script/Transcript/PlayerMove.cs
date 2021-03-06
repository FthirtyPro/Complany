﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float velocity = 5;
    private Animator anim;
	// Use this for initialization
	void Start () {

        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 newVel = rigidbody.velocity; //得到当前物体速度；

        if(Mathf.Abs(h)>0.05f|| (Mathf.Abs(v)>0.05f)) //keyboard Input
        {
            anim.SetBool("Move",true);
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("Empty State"))
            {
                 rigidbody.velocity = new Vector3(velocity * h, newVel.y, v * velocity);
                transform.LookAt(new Vector3(h, 0, v) + transform.position); //自身坐标+向量 --》》目标朝向

            }
         
        }
        else
        {
            rigidbody.velocity = new Vector3(0, newVel.y, 0); //没有按下键盘，Y轴不动。
            anim.SetBool("Move", false);

                
        }
	}
}
