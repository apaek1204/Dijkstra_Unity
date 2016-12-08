using UnityEngine;
using System.Collections;
using ConsoleApplication1;

public class movement : MonoBehaviour {




	public GameObject apple;


	public Vector3 applePosition;

	private string[] map;


	private int currentX;
	private int currentY;

	public float tileSize
	{
		get { return this.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
	}

	private float threshold;
	private float time;

	// Use this for initialization
	void Start () {

		currentX = 0;
		currentY = 0;
		map = GameObject.Find ("Manager").GetComponent<Manager> ().mapData;
		time = 0;
		threshold = 1.0f;
		applePosition = apple.transform.position;





	
	}




	void moveRight(){

		Vector3 moveX = new Vector3( tileSize ,0.0f , 0);
	}
	
	// Update is called once per frame
	void Update () {

		map = GameObject.Find ("Manager").GetComponent<Manager> ().mapData;



		if (time == 0) {

			Pathfind hello = new Pathfind();
			int result = hello.AStarAgain (map.Length, map.Length, currentX, currentY, 2, 2, map);

			Debug.Log ("result");

			Debug.Log (result);

		}


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
			Debug.Log (currentX);
			Debug.Log (currentY);
			Pathfind hello = new Pathfind();
			int result = Random.Range (0, 3);//hello.AStar (map.Length, map.Length, currentX, currentY, 2, 2, map);



			//int result = Pathfind.AStar (map.Length, map.Length, currentX, currentY, 2, 2, map);

			Debug.Log (result);



			if (result == 0) {

					currentX+=1;

				this.transform.Translate (moveX);


			} else if (result == 2) {
					currentX-=1;

				this.transform.Translate (-moveX);
			} else if (result == 3) {

					currentY+=1;
				this.transform.Translate (moveY);


			} else if (result == 1) {

					currentY-=1;
				this.transform.Translate (-moveY);
			}
	
		}
	
	}
}
