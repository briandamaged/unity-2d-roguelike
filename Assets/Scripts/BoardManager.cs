using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int rows = 8;
    public int cols = 8;

    public Range wallRange = new Range(5, 9);
    public Range foodRange = new Range(1, 5);


    public GameObject exit;
    public GameObject[] floorPrefabs;
    public GameObject[] innerWallPrefabs;
    public GameObject[] outerWallPrefabs;

    public GameObject[] enemyPrefabs;


    IEnumerable<Vector3> SolidRectangle(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            for (int y = y1; y <= y2; ++y) {
                yield return new Vector3(x, y, 0f);
            }
        }
    }

    IEnumerable<Vector3> HollowRectangle(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            yield return new Vector3(x, y1, 0f);
            yield return new Vector3(x, y2, 0f);
        }

        for (int y = y1 + 1; y < y2; ++y) {
            yield return new Vector3(x1, y, 0f);
            yield return new Vector3(x2, y, 0f);
        }
    }

	// Use this for initialization
	void Start () {
        foreach(Vector3 position in this.HollowRectangle(0, 0, this.cols, this.rows)) {
            Instantiate(this.outerWallPrefabs.PickRandom(), position, Quaternion.identity);
        }

        foreach(Vector3 position in this.SolidRectangle(1, 1, this.cols - 1, this.rows - 1)) {
            Instantiate(this.floorPrefabs.PickRandom(), position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
