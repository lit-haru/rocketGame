using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using unityroom.Api;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    public Text ResultText;
    public GameObject ResultUI;

    public int bestScore = 0;
    public Text bestScoreText;

    public float CountDownTime;
    public Text CountDownText;

    public bool isGamePlaying = false;
    
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        bestScore = PlayerPrefs.GetInt("SCORE", 0);
        CountDownTime = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        //カウントダウン
        CountDownText.text = string.Format("{0:00.00}", CountDownTime);
            CountDownTime -= Time.deltaTime;
            if (CountDownTime <= 0)
            {
                GameEnd();
            }

        if(Time.timeScale == 0)
        {
            isGamePlaying = false;
        }
        else
        {
            isGamePlaying = true;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
        score = 0;
        isGamePlaying = true;
    }

    public void GameEnd()
    {
        OpenResultPanel();
        CountDownTime = 0f;
    }
    public void OpenResultPanel()
    {
        ResultUI.SetActive(true);
        ResultText.text = score.ToString();

        if(bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("SCORE", bestScore);
            PlayerPrefs.Save();
        }
        bestScoreText.text = "BEST SCORE : " + bestScore.ToString();
        UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
    }
    public void AddScore()
    {
        score += 1;
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
