using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class FixPanel : MonoBehaviour {

    public GameObject errorPanel;
    public GameObject refreshButton;
    public GameObject cameraButton;
    private string s = "";
    private bool onOff = false;
	
	void Start () {
       s = SceneManager.GetActiveScene().name;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DefaultTrackableEventHandler.trueFalse==true)
        {
            errorPanel.SetActive(false);
            cameraButton.SetActive(false);
        }
	}
    public void Refresh()
    {
        SceneManager.LoadScene(s);
    }

    public void toggleFlash()
    {
        if(onOff==false)
        {
            CameraDevice.Instance.SetFlashTorchMode(true);
            onOff = true;
        }
        else
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
            onOff = false;
        }
    }
}
