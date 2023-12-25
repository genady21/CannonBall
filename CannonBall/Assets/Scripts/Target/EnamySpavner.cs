using System.Collections;
using UnityEngine;

public class EnamySpavner : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Transform _startPoint;

    [Space] [SerializeField] private Vector2 _randomPoX;
    [SerializeField] private Vector2 _randomPoY;

    [Space] [SerializeField] private int _countEnemy;
    [SerializeField] private int _cd;


    private void Start()
    {
        for (var i = 0; i < _countEnemy; i++) CreateTarget();
    }

    public void Spawn()
    {
        StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        yield return new WaitForSeconds(_cd);
        CreateTarget();
    }

    private void CreateTarget()
    {
        var target = Instantiate(_target, _startPoint);
        var position = target.transform.position;

        position.y = Random.Range(_randomPoY.x, _randomPoY.y);
        position.x = Random.Range(_randomPoX.x, _randomPoX.y);

        target.transform.position = position;

        target.Init(this);
    }
}