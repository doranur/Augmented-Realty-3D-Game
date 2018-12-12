using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class spawnerScript : DefaultTrackableEventHandler {

    public Text myScore;
    public static spawnerScript instance;
    private GameObject dancer;
    private Animator anim;
    public GameObject Instruct;
    private bool fired;
    public bool isGamePlaying=false;


    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

    }
        

   new void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (DefaultTrackableEventHandler.trueFalse==true && fired ==false){
            SpawnProcess();
            fired = true;
        }
        else if(DefaultTrackableEventHandler.trueFalse==false && fired == true) {
            fired = false;
            CancelInvoke();
        }
	}
    public void BeginGame()
    {
      
        gameController.instance.playMusic();
        Instruct.SetActive(false);
    }
    public void SpawnProcess()
    {
        InvokeRepeating("spawn", 2.5f, 2.5f);
        isGamePlaying = true;
    }
    void spawn()
    {
		GameObject x = (GameObject)Instantiate(Resources.Load ("pointButton"));
		x.transform.parent = transform;

        RectTransform position = x.GetComponent<RectTransform>();
        position.localPosition = new Vector3 (0, 10, 0);
		position.localScale = new Vector3 (0.6376393f,0.6376393f,0.6376393f);
    }
    public void addScore(int theScore)
    {
        myScore.text = (int.Parse(myScore.text) + theScore).ToString();
        removeKids();
         
    }
    private void removeKids()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }
    public void makeMove(string danceMove)
    {
        dancer = GameObject.Find("UserDefinedTarget-1/sporty_granny");
        anim = dancer.GetComponent<Animator>();
        anim.SetTrigger(danceMove);
    }
}
