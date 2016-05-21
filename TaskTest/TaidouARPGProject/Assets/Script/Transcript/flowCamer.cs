using UnityEngine;
using System.Collections;

public class flowCamer : MonoBehaviour {
    public Vector3 offset;
    private Transform playerBip;
    public float smoothing = 0.2f;
        

	// Use this for initialization
	void Start () {
        playerBip = GameObject.FindGameObjectWithTag("Player").transform.Find("Bip01");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targePos = playerBip.position + offset;
        transform.position = Vector3.Lerp(transform.position, targePos, smoothing * Time.deltaTime);
	
	}
}
