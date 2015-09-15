using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public GameObject platform;
	public float platformView = 10f;

	List<GameObject> platformList = new List<GameObject>();

	private int[][][] types = new int[][][]{
		/*#
		**#
		*/
		new int[][]{
			new int[]{0},
			new int[]{0},
			new int[]{0}
		},
		/*##
		**#
		*/
		new int[][]{
			new int[]{1},
			new int[]{0,1},
			new int[]{0}
		},
		/*##
		** #
		*/
		new int[][]{
			new int[]{-1},
			new int[]{-1,0},
			new int[]{0}
		},
		/*###
		**# #
		**###
		*/
		new int[][]{
			new int[]{0},
			new int[]{-1,0,1},
			new int[]{-1,1},
			new int[]{-1,0,1}
		}
	};

	private float platformZSize;

	private float platScaleZ;
	private float platScaleX;

	private float xStart = 0f;
	private float zStart = 7f;

	public static PlatformManager pInstance = null;

	// Use this for initialization
	void Start () {
		if (pInstance == null)
			pInstance = this;
		else if (pInstance != this)
			Destroy (gameObject);

		platScaleZ = platform.transform.localScale.z;
		platScaleX = platform.transform.localScale.x;

		platformZSize = platformView * platScaleZ;

		initPlatforms ();

		print (zStart);
		print (platformZSize);
	}

	void initPlatforms(){
		for (int i = 0; i < platformView; i+=types.Length) {
			addNewObject(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		zStart -= GameManager.instance.getGameSpeed ().z;
		if (zStart < platformZSize) {
			addNewObject (Random.Range (0, types.Length));
			addNewObject(0);
		}
	}

	void addNewObject(int t){
		for(int i = types[t].Length-1; i >= 0; i--){
			if(i == 0){
				xStart+=types[t][i][0]*platScaleX;
			}
			else{
				for(int j = 0; j < types[t][i].Length; j++){
					GameObject temp = Instantiate(platform, transform.position+(new Vector3(xStart+types[t][i][j]*platScaleX, -0.5f, zStart)), Quaternion.identity) as GameObject;
					platformList.Add(temp);
				}
				zStart+=platScaleZ;
			}
		}
	}
}
