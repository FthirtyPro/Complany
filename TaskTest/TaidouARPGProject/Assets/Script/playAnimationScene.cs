using UnityEngine;
using System.Collections;

public class playAnimationScene : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

	void Update () {
	    
        if(rigidbody.velocity.magnitude >0.5f)
        {
            anim.SetBool("Move", true);

        }else
        {
            anim.SetBool("Move", false);
        }
	}
}
