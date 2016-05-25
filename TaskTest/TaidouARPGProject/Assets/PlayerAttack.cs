using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();

    void Start()
    {
        PlayerEffect[] effArrary = this.GetComponentsInChildren<PlayerEffect>();
        foreach(PlayerEffect pr in effArrary)
        {
            effectDict.Add(pr.gameObject.name, pr);
        }
    }
    void Attack(string args)
    {
        string[] proArray = args.Split(',');
        string effectName = proArray[1];
        ShowPlayerEffect(effectName);


    }

    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        if(effectDict.TryGetValue(effectName,out pe))
        {
            pe.Show();
        }
    }
}
