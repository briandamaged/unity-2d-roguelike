
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    
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


    IEnumerable<Vector3> GetOuterWallPositions() {
        return Rectangles.GetHollowPositions(-1, -1, this.cols, this.rows);
    }

    IEnumerable<Vector3> GetFloorPositions() {
        return Rectangles.GetSolidPositions(0, 0, this.cols - 1, this.rows - 1);
    }

    IEnumerable<Vector3> GetVacantPositions() {
        return Rectangles.GetSolidPositions(1, 1, this.cols - 2, this.rows - 2);
    }

	void Start () {
        BoardInserter boardInserter = new BoardInserter(this.transform);

        boardInserter.Insert(this.outerWallPrefabs, this.GetOuterWallPositions());
        boardInserter.Insert(this.floorPrefabs, this.GetFloorPositions());

        VacanciesInserter vacancies = new VacanciesInserter(boardInserter, this.GetVacantPositions());

        vacancies.Insert(this.innerWallPrefabs, this.wallRange);
        vacancies.Insert(this.foodPrefabs, this.foodRange);
        vacancies.Insert(this.enemyPrefabs, this.enemyRange);
	}
	

}
