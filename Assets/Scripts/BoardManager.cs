
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public class BoardInserter {
        private Transform holder;

        public BoardInserter(Transform holder) {
            this.holder = holder;
        }

        public BoardInserter() : this(new GameObject("Board").transform) {
            // Already initialized!
        }

        public GameObject Insert(GameObject prefab, Vector3 position) {
            GameObject newObject = Instantiate<GameObject>(prefab, position, Quaternion.identity);
            newObject.transform.SetParent(this.holder);
            return newObject;
        }

        public GameObject Insert(GameObject[] prefabs, Vector3 position) {
            return this.Insert(prefabs.PickRandom(), position);
        }

        public IList<GameObject> Insert(GameObject[] prefabs, IEnumerable<Vector3> positions) {
            List<GameObject> retval = new List<GameObject>();
            foreach(Vector3 p in positions) {
                retval.Insert(0, this.Insert(prefabs, p));
            }
            return retval;
        }

        public VacanciesInserter CreateVacanciesInserter(IList<Vector3> vacancies) {
            return new VacanciesInserter(this, vacancies);
        }
    }


    public class VacanciesInserter {
        private BoardInserter boardInserter;
        private IList<Vector3> vacancies;

        public VacanciesInserter(BoardInserter boardInserter, IList<Vector3> vacancies) {
            this.boardInserter = boardInserter;
            this.vacancies = vacancies;
        }

        public VacanciesInserter(BoardInserter boardInserter, IEnumerable<Vector3> vacancies) : this(boardInserter, new List<Vector3>(vacancies)) {
            // Already initialized
        }

        public IList<GameObject> Insert(GameObject[] prefabs, int count) {
            return this.boardInserter.Insert(prefabs, Repeat.Times(count, this.vacancies.GrabRandom));
        }

        public IList<GameObject> Insert(GameObject[] prefabs, Range range) {
            return this.Insert(prefabs, range.PickRandom());
        }
    }

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


	void Start () {
        BoardInserter boardInserter = new BoardInserter(this.transform);

        boardInserter.Insert(this.outerWallPrefabs, this.GetOuterWallPositions());
        boardInserter.Insert(this.floorPrefabs, this.GetFloorPositions());

        VacanciesInserter vacancies = new VacanciesInserter(boardInserter, this.GetFloorPositions());

        vacancies.Insert(this.innerWallPrefabs, this.wallRange);
        vacancies.Insert(this.foodPrefabs, this.foodRange);
        vacancies.Insert(this.enemyPrefabs, this.enemyRange);
	}
	

}
