using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public ArcadeKart kart;
    public TrackTutorial[] tracks;
    public OrbTutorial[] orbs;
    public CinemachineVirtualCamera camera;
    bool gameReady;
    public GameObject TutorialCanvas;
    public GameObject InGameCanvas;
    public GameObject EndGame;
    public TextMeshProUGUI Objective;
    public TextMeshProUGUI Avance;

    void Start()
    {
        tracks = FindObjectsOfType<TrackTutorial>();
        orbs = FindObjectsOfType<OrbTutorial>();
        gameReady = false;
    }

    public void StartTutorial()
    {
        TutorialCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
        kart.isLocalPlayer = true;
        gameReady = true;
        camera.m_Follow = kart.gameObject.transform;
        camera.m_LookAt = kart.gameObject.transform;
        ActivateTracks();
    }

    void ActivateTracks()
    {
        foreach(TrackTutorial track in tracks)
            track.ExplodeTrack();
    }

    public void AddScore()
    {
        string str = Avance.text;
        int tracks = int.Parse(str.Substring(0, 1));
        Avance.text = (tracks + 1).ToString() + " / 2";
        if(tracks + 1 == 2)
        {
            InGameCanvas.SetActive(false);
            EndGame.SetActive(true);

            Invoke("EndTutorial", 3f);
        }
    }

    void EndTutorial()
    {
        SceneManager.LoadScene("IntroMenu");
    }

    void Update()
    {
        if(!gameReady)
            camera.transform.RotateAround(kart.transform.position, Vector3.up, 20 * Time.deltaTime);
        if(kart.TrackAssign != -1)
            Objective.text = "Repair the track with beacon";
        else
            Objective.text = "Pick up an orb";
    }
}
