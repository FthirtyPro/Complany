using UnityEngine;
using System.Collections;

public class autoMoveLath : MonoBehaviour {

    private NavMeshAgent agent;
    public float minDistance = 3;

   /// public Transform tar;

	// Use this for initialization
	void Start () {

        agent = this.GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(agent.enabled)
        {
            if (agent.remainingDistance < minDistance && agent.remainingDistance !=0) //注意距离默认为0
            {
                print("stop"+ agent.remainingDistance );
                //UITaskTween.PlayReverse();
                agent.Stop();
                agent.enabled = false;
                TaskManager._instance.OnArriveDestination();//接近Npc后弹出对话框。
            }
        }

        //测试代码
        //if(Input.GetMouseButtonDown(0))
        //{
        //    SetDestination(tar.position);
        //}
	}

    public void SetDestination(Vector3 targPos)
    {
        ///设置目标，使自动寻路走过去。
        ///
        print("par" + targPos);
       

        agent.enabled = true;
        agent.SetDestination(targPos);

    }
}
