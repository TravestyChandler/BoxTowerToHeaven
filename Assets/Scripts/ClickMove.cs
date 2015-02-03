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
					print("Box");
					selectedBox = hit.collider.gameObject;
				
				}
				if(hit.collider.tag == "Tree"){
					hit.collider.gameObject.SendMessage("OnClick");
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			selectedBox = null;
		}
		if(selectedBox != null){
			BoxCollision box = selectedBox.GetComponent<BoxCollision>();
			float newX = Mathf.Clamp(mousePos.x,  box.startPos.x - box.maxXChange, box.startPos.x + box.maxXChange);
			selectedBox.transform.position = new Vector3(newX, selectedBox.transform.position.y, selectedBox.transform.position.z);
		}
	}

}
