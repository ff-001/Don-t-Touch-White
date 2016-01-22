using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnButton : MonoBehaviour
{
	public static ReturnButton _instance;
	private GameController gameController;
	public Text restartWait;
	public bool REstart = false;
	float RETimer = 10f;
	float s = 10f;
	
	void Awake(){
		_instance=this;
	}


    	void Start()
    	{
        	gameController = GameObject.FindObjectOfType<GameController>();
//		KTPlay.ShowInterstitialNotification();
    	}

    	// Update is called once per frame
    	void Update()
    	{
		if(REstart){
			RETimer -= Time.deltaTime;
			s = (int)RETimer;
			if(s>=0){
				restartWait.text = "Try Again (" + s + ")";
			}
		}
    	}
    	void OnMouseDown()
    	{
        	gameController.ReturnStartUI();
    	}

	public void ReadyToRestart(){
		REstart = true;
	}


	public void Restart(){
		if(RETimer < 0){
			gameController.RestartGameUI();
			RETimer = 10f;
			REstart = false;
		}
	}

}
