using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class TrackController : MonoBehaviour
{    
    [Header("OrbController")]
    public OrbController orbController;

    [Header("Tracks")]
    public Track[] tracks;

    [Header("Change to Competitive")]
    public bool IsInCompetitive = false;
    public GameFlowManager manager;
    public AudioClip SuccessSound;

    public void Update()
    {
        if(IsInCompetitive)
        {
            bool allRepaired = true;
            foreach(Track track in tracks)
            {
                if(!track.isRepaired)
                {
                    allRepaired = false;
                    break;
                }
            }
            if(allRepaired)
            {
                IsInCompetitive = true;
                manager.StartCompetition();
                if (SuccessSound)
                    AudioUtility.CreateSFX(SuccessSound, transform.position, AudioUtility.AudioGroups.Collision, 0f);
            }
        }
    }

    // public void SelectTracks(int randomNumber)
    public void SelectTracks()
    {
        int randomTrack;
        for (int index = 0; index < 10; ++index) {
            tracks[index].TrackNumber = index;
            tracks[index].identification = index;
        }

        Invoke("ExplodeTracks", 3f);
    }

    public void Explode3fTracks()
    {
        Invoke("ExplodeTracks", 3f);
    }

    public void ExplodeTracks()
    {
        //tracks = FindObjectsOfType<Track>();
        foreach (Track track in tracks)
            track.ExplodeTrack();
    }
}
