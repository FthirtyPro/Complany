using UnityEngine;
using System.Collections;

public class PlayMove : MonoBehaviour {

    public float velocity = 5;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = rigidbody.velocity;
        rigidbody.velocity = new Vector3(-h * velocity, vel.y, -v * velocity);

        if(Mathf.Abs(h) > 0.05f || Mathf.Abs(v)>0)
        {

            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v)); //控制目标的朝向（键盘按下）；
        }

    }

	
}
