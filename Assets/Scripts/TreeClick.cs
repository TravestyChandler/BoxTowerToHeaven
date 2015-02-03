using UnityEngine;
using System.Collections;

public class TreeClick : MonoBehaviour {
	public ParticleSystem part;
	public float emission = 50f;
	public float length = 1.5f;
	// Use this for initialization
	void Start () {
		part.renderer.sortingLayerName = "Particles";
		part.emissionRate = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		StartCoroutine(SnowParts());
	}

	public IEnumerator SnowParts(){
		part.emissionRate = emission;
		yield return new WaitForSeconds(length);
		part.emissionRate = 0f;
	}
}
