using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {
	public GameObject selectedBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if(Input.GetKeyDown (KeyCode.Mouse0)){
			RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
			if(hit.collider != null){
				if(hit.collider.tag == "Box"){
					print("hit");
						selectedBox = hit.collider.gameObject;
					//	selectedBox.AddComponent<Rigidbody>();
					//	selectedBox.rigidbody.useGravity = false;
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			//Destroy(selectedBox.gameObject.GetComponent<Rigidbody>());
			selectedBox = null;
		}
		if(selectedBox != null){

			selectedBox.transform.position = mousePos;
		}
	}

}
