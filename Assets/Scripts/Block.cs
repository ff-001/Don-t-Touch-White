using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public int score;
    private float xOff = -2.13f;
    private float yOff = -3.9f;
    public int rowIndex;
    public int columnIndex;

    public Color selected;

    public Vector3 targetPos;
    public float moveSpeed = 2;
    public bool isMove = false;
    public  float timer;



    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (isMove)
        {
            timer += Time.deltaTime;
            MovePosition(targetPos, timer * moveSpeed);
            if (timer >= 1)
            {
                isMove = false;


            }
        }
    }


    void OnMouseDown()
    {


        gameController.Select(this);
        GetComponent<SpriteRenderer>().color=selected;
        GetComponent<BoxCollider2D>().enabled = false;

    }

    public void MovePosition(Vector3 tgtPos, float tmr)
    {
        transform.position = Vector3.Lerp(transform.position, tgtPos, tmr);
    }

    public Vector3 GetPosition()
    {
        int c = columnIndex;
        int r = rowIndex;
        return new Vector3(xOff + c * 1.42f, yOff + r * 2.12f, 0);
    }

}
