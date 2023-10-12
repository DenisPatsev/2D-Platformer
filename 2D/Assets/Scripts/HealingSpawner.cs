using System.Collections;
using UnityEngine;

public class HealingSpawner : MonoBehaviour
{
    [SerializeField] private Potion _potion;
    [SerializeField] private PotionSpawner[] _generators;

    private Transform _spawnerTransform;

    private float _secondCount;
    private int minimalPointNumber;
    private int maximalPointNumber;
    private bool _isWorking;
    private float _secondNumber;

    private void Start()
    {
        minimalPointNumber = 0;
        maximalPointNumber = _generators.Length;
        _secondNumber = 10;

        _isWorking = true;

        StartCoroutine(Generate(_secondNumber));

        _secondCount = 0;
    }

    private void Update()
    {
        int second = Mathf.FloorToInt(Time.time);

        if (second > _secondCount)
        {
            _secondCount++;
        }
    }

    private IEnumerator Generate(float secondsNumber)
    {
        var wait = new WaitForSeconds(secondsNumber);

        while (_isWorking)
        {
            int index = Random.Range(minimalPointNumber, maximalPointNumber);

            for (int i = 0; i < _generators.Length; i++)
            {
                if (i == index)
                {
                    _spawnerTransform = _generators[i].transform;
                    GeneratePotion(_spawnerTransform.position);
                }
            }

            yield return wait;
        }
    }

    private void GeneratePotion(Vector3 position)
    {
        Instantiate(_potion, position, Quaternion.identity);
    }
}
