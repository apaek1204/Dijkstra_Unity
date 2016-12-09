using UnityEngine;
using System.Collections;


public class grass : MonoBehaviour {

	// Use this for initialization



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);

		if(hit.collider != null)
		{
			//Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);

			if ((Input.GetMouseButtonDown (0)) && (hit.collider.gameObject.transform.position == gameObject.transform.position)){


				Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));


				Vector3 current = new Vector3 ( gameObject.transform.position.x - worldStart.x ,(-1.0f)*(gameObject.transform.position.y - worldStart.y ), 0.0f);

				Debug.Log ((int)(worldStart.x));


				Debug.Log ((int)(gameObject.transform.position.x));


				int tileSize = (int)gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

				Vector3 position = gameObject.transform.position; 

				Debug.Log ("moutain?");
				Debug.Log ((int)(current.x / tileSize));
				Debug.Log ((int)(current.y / tileSize));
				Debug.Log ("moutain?");
				GameObject.Find ("Manager").GetComponent<Manager> ().updateMap ((int)(current.x/tileSize), (int)(current.y/tileSize),position );
				Destroy (gameObject);
			}

		}
	}
}
