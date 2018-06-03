using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInserter {
    private Transform holder;

    public BoardInserter(Transform holder) {
        this.holder = holder;
    }

    public BoardInserter() : this(new GameObject("Board").transform) {
        // Already initialized!
    }

    public GameObject Insert(GameObject prefab, Vector3 position) {
        GameObject newObject = GameObject.Instantiate<GameObject>(prefab, position, Quaternion.identity);
        newObject.transform.SetParent(this.holder);
        return newObject;
    }

    public GameObject Insert(GameObject[] prefabs, Vector3 position) {
        return this.Insert(prefabs.PickRandom(), position);
    }

    public IList<GameObject> Insert(GameObject[] prefabs, IEnumerable<Vector3> positions) {
        List<GameObject> retval = new List<GameObject>();
        foreach (Vector3 p in positions) {
            retval.Insert(0, this.Insert(prefabs, p));
        }
        return retval;
    }

    public VacanciesInserter CreateVacanciesInserter(IList<Vector3> vacancies) {
        return new VacanciesInserter(this, vacancies);
    }
}
