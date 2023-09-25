using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    private TMP_Text _coinCount;
    private float _count;

    private void Start()
    {
        _count = 0;
        _coinCount = GetComponent<TMP_Text>();
        _coinCount.text = "�oins = " + _count;
    }

    private void Update()
    {
        _coinCount.text = "�oins = " + _count;
    }

    public void AddCoins()
    {
        _count++;
    }
}