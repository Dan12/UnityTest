using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public GameObject platform;
	public int platformView = 10;

	List<GameObject> myList = new List<GameObject>();

	private int[][,][,] types = new int[3][,][,]{
		//#
		//#
		new int[,][,]{
			int[,]{0},
			int[,]{0}
		},
		//##
		// #
		new int[,][,]{
			{0},
			{-1,0}
		},
		//##
		//#
		new int[,][,]{
			{0},
			{0,1}
		}
	};

	private float platScaleZ;
	private float platScaleX;

	private int xStart = 0;
	private float yStart = 6f;

	// Use this for initialization
	void Start () {
		platScaleZ = platform.transform.localScale.z;
		platScaleX = platform.transform.localScale.x;

		initPlatforms ();
	}

	void initPlatforms(){
		for (int i = 0; i < platformView; i+=types.Length) {
			addNewObject(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addNewObject(int t){
		for(int i = 0; i < types[t].Length; i++){
			for(int j = 0; j < types[t][i].Length; j++){
				GameObject temp = Instantiate(platform, transform.position+(new Vector3(xStart+types[t][i][j]*platScaleX, 0f, yStart)), Quaternion.identity) as GameObject;
			}
			yStart+=platScaleZ;
		}
	}
}
