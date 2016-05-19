using UnityEngine;
using System.Collections;

public class TranscriptManager : MonoBehaviour {

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
