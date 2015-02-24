using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour
{

    private float radian = 0;
    public float perRadian = 0.02f;
    public float radius = 0.2f;

    Vector3 oldPos;
    float dy;

    // Use this for initialization
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        radian += perRadian;
        dy = Mathf.Cos(radian);
        transform.position = oldPos + new Vector3(0, dy*radius, 0);
    }
}
