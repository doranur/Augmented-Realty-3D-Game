using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class errorPanel : MonoBehaviour {

	public GameObject MyErrorMsg;
	public bool trueFalse;
	public static errorPanel instance;


	void Awake(){
		if(instance==null){
			instance = this;
		}
		MyErrorMsg.gameObject.SetActive(false);
	}


	// Update is called once per frame
	public void Toggle (bool trueFalse) {
		if(trueFalse == false){
			MyErrorMsg.gameObject.SetActive(true);
			trueFalse = true;
 			return;
		}else if(trueFalse){
			MyErrorMsg.gameObject.SetActive(false);
 			trueFalse = false;
			return;
			}
	}
}
