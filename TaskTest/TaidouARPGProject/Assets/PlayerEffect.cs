using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour {

    private Renderer[] renderArray;
    private NcCurveAnimation[] ncCurveAni;

	// Use this for initialization
	void Start () {

       renderArray = this.GetComponentsInChildren<Renderer>();
       ncCurveAni = this.GetComponentsInChildren<NcCurveAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
	

        if(Input.GetMouseButtonDown(0))
        {
            Show();
        }
	}

    void Show()
    {
        foreach(Renderer render in renderArray)
        {
            render.enabled = true;
        }

        foreach(NcCurveAnimation anieffect in ncCurveAni)
        {
            anieffect.ResetAnimation();
        }
    }
}
