using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using KartGame.KartSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//using Mirror;

public enum GameState { State2, Tie, Won, Lost, Play }

public class GameFlowManager : MonoBehaviour
{
    
    [Header("Show score text ")]
    public TextMeshProUGUI textScore1;
    public TextMeshProUGUI textScore2;
    public TextMeshProUGUI errorConnection;
    public int score1 ;
    public int score2 ;
    public bool  StartGame;

    [Header("Parameters")]
    [Tooltip("Duration of the fade-to-black at the end of the game")]
    public float endSceneLoadDelay = 3f;
    [Tooltip("The canvas group of the fade-to-black screen")]
    public CanvasGroup endGameFadeCanvasGroup;

    [Header("State2")]
    [Tooltip("This string has to be the name of the scene you want to load when State2")]
    public string state2SceneName = "State2Scene";
    [Tooltip("Prefab for the State2 game message")]
    public DisplayMessage state2DisplayMessage;

    [Header("Tie")]
    [Tooltip("This string has to be the name of the scene you want to load when Tie")]
    public string tieSceneName = "TieScene";
    [Tooltip("Prefab for the Tie game message")]
    public DisplayMessage tieDisplayMessage;

    [Header("Win")]
    [Tooltip("This string has to be the name of the scene you want to load when winning")]
    public string winSceneName = "WinScene";
    [Tooltip("Duration of delay before the fade-to-black, if winning")]
    public float delayBeforeFadeToBlack = 4f;
    [Tooltip("Duration of delay before the win message")]
    public float delayBeforeWinMessage = 2f;
    [Tooltip("Sound played on win")]
    public AudioClip victorySound;
    [Tooltip("Prefab for the win game message")]
    public DisplayMessage winDisplayMessage;
    public PlayableDirector raceCountdownTrigger;


    [Header("Lose")]
    [Tooltip("This string has to be the name of the scene you want to load when losing")]
    public string loseSceneName = "LoseScene";
    [Tooltip("Prefab for the lose game message")]
    public DisplayMessage loseDisplayMessage;

    public Text endGame;

    public GameState gameState { get; private set; }

    public bool autoFindKarts = true;
    public ArcadeKart playerKart;

    public ArcadeKart[] karts;
    
    public int myScore = 0;

    ObjectiveManager m_ObjectiveManager;
    TimeManager m_TimeManager;
    float m_TimeLoadEndGameScene;
    string m_SceneToLoad;
    float elapsedTimeBeforeEndScene = 0;

    [Header("Managing state of game")]
    public int gamePhase;

    [Header("DisplayMessage")]
    public DisplayMessage displayMessage;

    [Header("Track manager")]
    bool isGameReady;
    public TrackController TC;
    public OrbController OC;
    public KartController[] kartsControllers;
    public DisplayScore[] kartsScore;
   
    void Start()
    {
        //initialize the text 
        //textScore1 = GameObject.Find("TextScore1").GetComponent<TextMeshProUGUI>();
        //textScore2 = GameObject.Find("TextScore2").GetComponent<TextMeshProUGUI>();
        gamePhase = 0;
        isGameReady = false;
        StartGame = false;

        //if (playerKart == null) return;
        if (autoFindKarts)
        {
            karts = FindObjectsOfType<ArcadeKart>();
            if (karts.Length > 0)
            {
                if (!playerKart) playerKart = karts[0];
            }
            DebugUtility.HandleErrorIfNullFindObject<ArcadeKart, GameFlowManager>(playerKart, this);
        }

        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
        DebugUtility.HandleErrorIfNullFindObject<ObjectiveManager, GameFlowManager>(m_ObjectiveManager, this);

        m_TimeManager = FindObjectOfType<TimeManager>();
        DebugUtility.HandleErrorIfNullFindObject<TimeManager, GameFlowManager>(m_TimeManager, this);

        AudioUtility.SetMasterVolume(1);

        winDisplayMessage.gameObject.SetActive(false);
        loseDisplayMessage.gameObject.SetActive(false);
        tieDisplayMessage.gameObject.SetActive(false);
        m_TimeManager.StopRace();
        //run race countdown animation
    }

    public void subGameReady()
    {
        karts = FindObjectsOfType<ArcadeKart>();
        isGameReady = true;
        gameState = GameState.Play;
        GameReady();
    }

    public void subGameReady2()
    {
        //StartGame = true;
        gameState = GameState.Play;
    }

    public void GameReady()
    {
        //karts = FindObjectsOfType<ArcadeKart>();

        ShowRaceCountdownAnimation();
        StartCoroutine(ShowObjectivesRoutine());

        StartCoroutine(CountdownThenStartRaceRoutine());

        kartsControllers = FindObjectsOfType<KartController>();
        
        foreach (KartController kart in kartsControllers)
        {

            TC.SelectTracks();
            OC.CreateOrbs();   
            break;
        }
    }

    IEnumerator CountdownThenStartRaceRoutine()
    {
        yield return new WaitForSeconds(3f);
        StartRace();
    }

    void StartRace()
    {
        foreach (ArcadeKart k in karts)
        {
            k.SetCanMove(true);
        }
        m_TimeManager.StartRace();
    }

    void ShowRaceCountdownAnimation()
    {
        raceCountdownTrigger.Play();
    }

    IEnumerator ShowObjectivesRoutine()
    {
        while (m_ObjectiveManager.Objectives.Count == 0)
            yield return null;
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < m_ObjectiveManager.Objectives.Count; i++)
        {
            if (m_ObjectiveManager.Objectives[i].displayMessage) m_ObjectiveManager.Objectives[i].displayMessage.Display();
            yield return new WaitForSecondsRealtime(1f);
        }
    }


    /*
    Tutorial:
    - Añadir scripts: 4 (tutorial) trakcTutorial, orbTutorial, Tutorial Controller, 
    - Modifique ArcadeKart, prevencion de errores
    - Añadi una escena 
    - Modifique el introMenu
    
    Estados de descnexion y ganar:
        -Agregue un script show score
        -Agregue una scena tie
        -Modifique scenas Win
        -Modifique scenas Lost
        -Modifique todo el gameflowmanager        
    */


    void Update()
    {
        if (gameState != GameState.Play )
        {
            print("************PRIMERO**********************");
            elapsedTimeBeforeEndScene += Time.deltaTime;
            if (elapsedTimeBeforeEndScene >= endSceneLoadDelay && StartGame )//&& StartGame
            {

                float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / endSceneLoadDelay;
                endGameFadeCanvasGroup.alpha = timeRatio;

                float volumeRatio = Mathf.Abs(timeRatio);
                float volume = Mathf.Clamp(1 - volumeRatio, 0, 1);
                AudioUtility.SetMasterVolume(volume);

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= m_TimeLoadEndGameScene )
                {
                    print("**************REALLY HERE************************");
                    PlayerPrefs.SetInt("Score1", score1);
                    PlayerPrefs.SetInt("Score2", score2);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(m_SceneToLoad);
                    //gameState = GameState.Play;
                }
            }
        }
        else
        {
            print("************SEGUNDO**********************");
            karts = FindObjectsOfType<ArcadeKart>();
            if (karts.Length == 2 && !isGameReady )
            {
                print("////////////////////////////////////////////////////////////////////////////////////");
                isGameReady = true;
                StartGame = true;
                gameState = GameState.Play;
                Invoke("GameReady",0.2f);
            }

            kartsScore = FindObjectsOfType<DisplayScore>();
            foreach (DisplayScore _score in kartsScore)
            {
                if(_score.gameObject.GetComponent<KartController>().playerID == 1){
                    textScore1.text = (_score.myScore).ToString();
                    score1 = _score.myScore;
                }else{
                    textScore2.text = (_score.myScore).ToString();
                    score2 = _score.myScore;
                }
            }
 
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
            {
                print("*ESTATE 0*");
                gameState = GameState.State2;
                EndGame(); // 0 == nextPartOfGame 
            }
                 

            if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
            {
                print("*ESTATE 1*");
                gameState = GameState.Lost;
                EndGame();
            }
                

            if (karts.Length == 1 && isGameReady && StartGame)
            {
                //isGameReady = false;
                
                if (score1 == score2)
                {
                    print("*ESTATE 3*");
                    gameState = GameState.Tie;
                }
                else if(score1 > score2) 
                {
                    print("*ESTATE 4*");
                    gameState = GameState.Won;
                }
                else
                {
                    print("*ESTATE 5*");
                    gameState = GameState.Lost;
                }
                EndGame();
            }
        }
    }

    void EnterCompetitive()
    {
        //gamePhase == 1;
        displayMessage.message = "Compete against the other player to win!";
    }

    //void EndGame(bool win)
    void EndGame()
    {
        
        // if( state == 0)
        // {
        //     EnterCompetitive();
        //     return;
        // }
        // Shutdown server for phone
        // endGame.text = "1";
        //NetworkManager.GetComponent<TurnItOff>().StopServer();


        // unlocks the cursor before leaving the scene, to be able to click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        m_TimeManager.StopRace();

        // Remember that we need to load the appropriate end scene after a delay
        //gameState = win ? GameState.Won : GameState.Lost;

        endGameFadeCanvasGroup.gameObject.SetActive(true);
        
        if(gameState == GameState.State2 ){
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;
            
            m_SceneToLoad = state2SceneName;
        }
        else if(gameState == GameState.Tie)
        {
            m_SceneToLoad = tieSceneName;
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            tieDisplayMessage.delayBeforeShowing = delayBeforeWinMessage;
            tieDisplayMessage.gameObject.SetActive(true);
        }
        else if (gameState == GameState.Won)
        {
            m_SceneToLoad = winSceneName;
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            // play a sound on win
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = victorySound;
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
            audioSource.PlayScheduled(AudioSettings.dspTime + delayBeforeWinMessage);

            // create a game message
            winDisplayMessage.delayBeforeShowing = delayBeforeWinMessage;
            winDisplayMessage.gameObject.SetActive(true);
        }
        else if(gameState == GameState.Lost)
        {
            m_SceneToLoad = loseSceneName;
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            // create a game message
            loseDisplayMessage.delayBeforeShowing = delayBeforeWinMessage;
            loseDisplayMessage.gameObject.SetActive(true);
        }
        return;
    }
}
