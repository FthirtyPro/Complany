using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TranscriptManager : MonoBehaviour {
    //private Dictionary<string, Object> enemylist = new Dictionary<string, Object>();

    public List<GameObject> enemyList = new List<GameObject>();
    public static TranscriptManager _instance;
    public GameObject Player;
    void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        

    }
}
