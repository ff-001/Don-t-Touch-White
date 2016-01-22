using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    private GameController gameController;

    void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    void OnMouseDown(){
        gameController.EnterGameUI();
    }
}
