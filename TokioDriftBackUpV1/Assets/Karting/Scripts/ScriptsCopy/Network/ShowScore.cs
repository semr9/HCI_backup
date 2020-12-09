using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using KartGame.KartSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShowScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text textScore1;
    public TMP_Text textScore2;
    private int score1 = 0;
    private int score2 = 0;
    void Start()
    {
        score1 = PlayerPrefs.GetInt("Score1");
        score2 = PlayerPrefs.GetInt("Score2");

    }
    // Update is called once per frame
    void Update()
    {
        textScore1.text = (score1).ToString();
        textScore2.text = (score2).ToString();
    }
}
