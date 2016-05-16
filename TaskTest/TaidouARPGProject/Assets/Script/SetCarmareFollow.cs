using UnityEngine;
using System.Collections;

public class SetCarmareFollow : MonoBehaviour {

    public Vector3 offset;
    private Transform player; //得到玩家位置


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = player.position + offset;
	
	}
}
