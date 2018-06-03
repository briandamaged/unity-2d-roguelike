
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    delegate void Inserter(Range range, GameObject[] prefabs);

    public int rows = 8;
    public int cols = 8;

    public Range wallRange = new Range(5, 9);
    public Range foodRange = new Range(1, 5);
    public Range enemyRange = new Range(1, 5);

    public GameObject exit;
    public GameObject[] floorPrefabs;
    public GameObject[] innerWallPrefabs;
    public GameObject[] outerWallPrefabs;

    public GameObject[] foodPrefabs;
    public GameObject[] enemyPrefabs;


    IEnumerable<Vector3> GetSolidRectanglePositions(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            for (int y = y1; y <= y2; ++y) {
                yield return new Vector3(x, y, 0f);
            }
        }
    }

    IEnumerable<Vector3> GetOuterWallPositions() {
        return this.GetHollowRectanglePositions(-1, -1, this.cols, this.rows);
    }

    IEnumerable<Vector3> GetHollowRectanglePositions(int x1, int y1, int x2, int y2) {
        for (int x = x1; x <= x2; ++x) {
            yield return new Vector3(x, y1, 0f);
            yield return new Vector3(x, y2, 0f);
        }

        for (int y = y1 + 1; y < y2; ++y) {
            yield return new Vector3(x1, y, 0f);
            yield return new Vector3(x2, y, 0f);
        }
    }

    IEnumerable<Vector3> GetFloorPositions() {
        return GetSolidRectanglePositions(0, 0, this.cols - 1, this.rows - 1);
    }

	// Use this for initialization
	void Start () {
        foreach(Vector3 position in this.GetOuterWallPositions()) {
            Instantiate(this.outerWallPrefabs.PickRandom(), position, Quaternion.identity);
        }

        foreach(Vector3 position in this.GetFloorPositions()) {
            Instantiate(this.floorPrefabs.PickRandom(), position, Quaternion.identity);
        }

        List<Vector3> openPositions = new List<Vector3>(this.GetFloorPositions());

        Inserter Insert = (Range range, GameObject[] prefabs) => {
            Repeat.Times(range.PickRandom(), () => {
                Instantiate(prefabs.PickRandom(), openPositions.GrabRandom(), Quaternion.identity);
            });
        };

        Insert(this.wallRange, this.innerWallPrefabs);
        Insert(this.foodRange, this.foodPrefabs);
        Insert(this.enemyRange, this.enemyPrefabs);
	}
	

}
