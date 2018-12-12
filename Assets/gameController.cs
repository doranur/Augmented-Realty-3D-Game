using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
    public GameObject HSPanel;
    private Animator anim;
    public Text HSText;
    public AudioClip clip;
    private  AudioSource a;
    public static gameController instance;
    public GameObject flashButton;

    private float theTimeLeft=60;
    public Text theTimer;
    public bool gameFinished =false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if(GamePreferences.getSave()== "" || GamePreferences.getSave() == null)
        {
            GamePreferences.save("0");

        }

    }

    // Use this for initialization
    void Start () {
      

         anim = HSPanel.GetComponent<Animator>();
         getHighScore();
         a=GetComponent<AudioSource>();
        //theTimeLeft = clip.length;
      

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "main")
        {

            if (spawnerScript.instance.isGamePlaying == true)
            {
                theTimeLeft -= Time.deltaTime;
                theTimer.text = "Time :" + theTimeLeft.ToString("f0");
                // int minutes = Mathf.FloorToInt(theTimeLeft / 60F);
                //int seconds = Mathf.FloorToInt(theTimeLeft - minutes*60);
                // theTimer.text = string.Format("Time:{0:0}:{1:0}", minutes, seconds);


                flashButton.SetActive(false);
            }
            else if (spawnerScript.instance.isGamePlaying == false)
            {
                flashButton.SetActive(false);
            }

            if (theTimeLeft < 0)
            {
                gameOver();
            }

        }


    }


    public void playGame()
    {
        SceneManager.LoadScene("main");
    }
    public void backToIntro()
    {
        SceneManager.LoadScene("intro");
    }
    public void playMusic()
        {
        a.Play();
    }
    public void Ouit()
    {
        Application.Quit();
    }
    public void stopMusic()
    {
        a.Stop();
    }


    public void playHSPanel()
    {
        anim.SetTrigger("playHSAnim");
    }
    public void backHSPanel()
    {
        anim.SetTrigger("goBack");
    }
    public void gameOver()
    {
        gameFinished = true;
        theTimer.text = "Time : 0";
        stopMusic();
        spawnerScript.instance.CancelInvoke();
        playHSPanel();
        HSText.text = spawnerScript.instance.myScore.text.ToString();
        string a = GamePreferences.getSave();
        string b = HSText.text.ToString();

        if((int.Parse(a)<(int.Parse(b))))
        {
            GamePreferences.save(HSText.text);

        }
       

    }
    private void getHighScore()
    {
       HSText.text= GamePreferences.getSave();
    }
}
public static class GamePreferences
{
    public static string HighScore = "0";
    public static void save(string score)
    {
        PlayerPrefs.SetString(GamePreferences.HighScore, score);
    }

    public static string getSave()
    {
        return PlayerPrefs.GetString(GamePreferences.HighScore);
    }
}
