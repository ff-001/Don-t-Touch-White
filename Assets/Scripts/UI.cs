using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text result;
    public static UI _instance;
    Text scoreDisplay;
    void Awake()
    {
	_instance = this;
        scoreDisplay = GetComponent<Text>();
    }

    void Update()
    {
        scoreDisplay .text= "Score: " + GameController.score;
    }

    public void ShowResult(){
	result.text = GameController.score.ToString();
    }


}
