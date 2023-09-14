using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins;

    private void Start()
    {
        _coins = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            Destroy(collision.gameObject);
            Debug.Log("Монеты: " + _coins);
        }
    }
}
