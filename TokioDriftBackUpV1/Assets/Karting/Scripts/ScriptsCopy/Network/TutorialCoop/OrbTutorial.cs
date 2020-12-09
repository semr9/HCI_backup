using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using KartGame.KartSystems;

public class OrbTutorial : MonoBehaviour
{
    private KartController asd;

    [Header("Orb stat")]
    public int trackAsignationForOrbe = -1;
    public bool isCollected = false;
    public int playerID;
    public TrackTutorial[] tracks;

    void Start()
    {
        tracks = FindObjectsOfType<TrackTutorial>();
    }

    void activateTrack()
    {
        foreach(TrackTutorial track in tracks)
            if(track.TrackNumber == trackAsignationForOrbe)
            {
                track.MyOrbIsActive();
                break;
            }
    }

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
        //Hit another player
        if (co.tag.Equals("Player"))
        {
            ArcadeKart kart = co.gameObject.GetComponent<ArcadeKart>();
            //print(kart);
            //print(co.gameObject.GetComponent<ArcadeKart>());
            if (kart && kart.TrackAssign == -1 && kart.playerID == playerID)
            {
                //set the tracker corresponce  
                isCollected = true;
                kart.TrackAssign = trackAsignationForOrbe;
                DestroyGameObject();
                activateTrack();
            }
        }
    }
}
