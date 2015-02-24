using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    private GameController gameController;
    

	void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        gameController.EnterGameUI();
    }
    
    
}
