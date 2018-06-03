using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
