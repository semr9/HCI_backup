using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class Meta : MonoBehaviour
{

    [Header("Meta stat")]
    public bool  value = false;
    public GameFlowManager manager;

    public void DestroyGameObject()
    {
        Destroy(gameObject, 1);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    void OnTriggerEnter(Collider co)
    {
        ArcadeKart kart = co.GetComponent<ArcadeKart>();
        //Hit another player
        if (co.tag.Equals("Player") && value == false)
        {
            if(co.GetComponent<KartController>().playerID == 1){
                print("SCORE1");
                manager.score1 += 200;
            }else{ 
                print("SCORE2");
                manager.score2 += 200;
            }
            manager.checkWinner();
            //co.GetComponent<ArcadeKart>().myScore += 200;
            //manager.idMeta = co.GetComponent<ArcadeKart>();   
            value = true;
        }
    }
}
