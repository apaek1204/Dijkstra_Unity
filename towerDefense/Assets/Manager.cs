using UnityEngine;
using System.Collections;
using System;

public class Manager : MonoBehaviour {

	[SerializeField]
	private GameObject[] tilePrefabs;

//	[SerializeField]
//	private CameraMovement cameraMovement;


	public GameObject Hero;


	public float tileSize
	{
		get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
	}





	// Use this for initialization
	void Start () {
		CreateLevel();
	}

	private void CreateLevel()
	{
		string[] mapData = ReadLevelText();


		int mapX = mapData[0].ToCharArray().Length;
		int mapY = mapData.Length;



		//char[] newTiles = mapData [0].ToCharArray ();


		Vector3 maxTile = Vector3.zero;

		Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));


		Vector3 heroStart = new Vector3 (worldStart.x, worldStart.y, -1.0f);


		Hero.transform.position = heroStart;

		//Debug.Log (newTiles[0]);


		for(int y = 0; y < mapY; y++)
		{

		

			char[] newTiles = mapData[y].ToCharArray();





			for(int x = 0; x < mapX; x++)
			{
				string entry = "";

				
				entry += newTiles [x];



				maxTile = PlaceTile(entry, x, y, worldStart); 
			}
				
		}

		//cameraMovement.SetLimits(new Vector3(maxTile.x + tileSize, maxTile.y - tileSize));
	}

	private Vector3 PlaceTile(string tileType, int x, int y, Vector3 worldStart)
	{
		int tileIndex = int.Parse(tileType); 

		Debug.Log (tileType);



		GameObject newTile = Instantiate(tilePrefabs[tileIndex]);
		newTile.transform.position = new Vector3(worldStart.x + (tileSize * x), worldStart.y - (tileSize * y), 0);
		return newTile.transform.position;
	}

	private string[] ReadLevelText()
	{



		TextAsset bindData = Resources.Load("Level") as TextAsset;


		//TextAsset map = (TextAsset)Resources.Load("Level", typeof(TextAsset));



		Debug.Log ("here");

		//Debug.Log (bindData);

		string data = bindData.text.Replace(Environment.NewLine, string.Empty);



		Debug.Log (data);
		Debug.Log ("data");


		return data.Split('-');
	}
}