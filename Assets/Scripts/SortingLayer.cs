using UnityEngine;
using System.Collections;

public class SortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	GetComponent<ParticleSystem>().renderer.sortingLayerName="Particles";
	}
	
	// Update is called once per frame
	void Update () {
        	Destroy(gameObject, 2);
	}
}
