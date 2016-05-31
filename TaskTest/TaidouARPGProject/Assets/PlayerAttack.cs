using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();

    public float distanceAttackForward = 2;
    public float distanceAttackRound = 2;

    public int[] damageArray =new int[] { 20, 30, 30, 30 };
    public enum AttackRange
    {
        Forward,
        Around
    }
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
        string sounder = proArray[2];
        Soundmanager._instance.PlayerSound(sounder);
        float moverDis =float.Parse( proArray[3]);
        if(moverDis>0.1f)
        {
            iTween.MoveBy(this.gameObject, Vector3.forward * moverDis, 0.3f);

        }

        string pos = proArray[0];
        if(pos=="normal")
        {
            ArrayList enerylist = GetEnemyInAttackRange(AttackRange.Forward);
            
                foreach(GameObject go in enerylist)
                {
                    go.SendMessage("TakeDamage", damageArray[0] + "," + proArray[3] + "," + proArray[4]);
                }

           
        }




    }

    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        if(effectDict.TryGetValue(effectName,out pe))
        {
            pe.Show();
        }
    }

    //检测攻击范围内的敌人
    // 得到在攻击范围内的敌人
    ArrayList GetEnemyInAttackRange(AttackRange attackRange)
    {
        ArrayList arrayList = new ArrayList();
        if (attackRange == AttackRange.Around)
        {
            foreach (GameObject go in TranscriptManager._instance.enemyList)
            {
                Vector3 pos = (transform.InverseTransformPoint(go.transform.position));
                //转换得到当前的相对坐标

                if (pos.z > -0.5f)
                {
                    float distance = Vector3.Distance(Vector3.zero, pos);
                    if (distance < distanceAttackForward)
                    {
                        arrayList.Add(go);
                    }
                }

            }
        }
        else
        {
            foreach (GameObject go in TranscriptManager._instance.enemyList)
            {
                //Vector3 pos = (transform.InverseTransformPoint(go.transform.position));
                //转换得到当前的相对坐标
                float distance = Vector3.Distance(transform.position, go.transform.position);

                if (distance < distanceAttackForward)
                {
                    arrayList.Add(go);
                }
            }

        }


        return arrayList;
    }


    }

  


