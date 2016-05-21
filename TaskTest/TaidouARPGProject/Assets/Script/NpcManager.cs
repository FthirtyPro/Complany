using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcManager : MonoBehaviour {

    public static NpcManager _instance;
    public GameObject[] NpcArray;
    private Dictionary<int, GameObject> npcDict = new Dictionary<int, GameObject>();

    void Awake()
    {
        _instance = this;
        Init();
    }
    void Init()
    {
        foreach(GameObject npc in NpcArray)
        {
            int id = int.Parse(npc.name.Substring(0, 4));
            npcDict.Add(id, npc);
        }

    }

    public GameObject GetNpcById(int Id)
    {
        GameObject npc = null;
        bool isExit = npcDict.TryGetValue(Id, out npc);
        return npc;
    }

}
