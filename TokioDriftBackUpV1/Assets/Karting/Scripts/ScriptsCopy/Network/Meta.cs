using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class Meta : MonoBehaviour
{

    [Header("Meta stat")]
    public bool  value = false;
    
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
            value = true;
        }
    }
}
