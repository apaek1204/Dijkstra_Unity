using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {




	public GameObject apple;


	public Vector3 applePosition;




	public float tileSize
	{
		get { return this.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
	}

	private float threshold;
	private float time;

	// Use this for initialization
	void Start () {
		time = 0;
		threshold = 1.0f;



	applePosition = apple.transform.position;



	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;


		Vector3 applePositon = apple.transform.position;


		//Vector3 moveX = new Vector3 ( 0.1f, 0.0f, 0.0f);
		//ector3 moveY = new Vector3 ( 0.0f, 0.1f, 0.0f);

		Vector3 moveX = new Vector3( tileSize ,0.0f , 0);
		Vector3 moveY = new Vector3( 0.0f ,tileSize , 0);




		//newPos= curr + direction * tileSize


			//Vector3( tileSize,0.0f, 0);



		if (time > threshold) {
			time = 0.0f;

			if (this.transform.position.x < applePositon.x) {


				this.transform.Translate (moveX);


			} else if (this.transform.position.x > applePositon.x) {


				this.transform.Translate (-moveX);
			} else if (this.transform.position.y < applePositon.y) {


				this.transform.Translate (moveY);


			} else if (this.transform.position.y > applePositon.y) {


				this.transform.Translate (-moveY);
			}
	
		}
	
	}
}
