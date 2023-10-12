using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _coinTrigger;

    private const string TakeHit = "takeDamage";

    private Animator _animator;

    private float _health;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _health = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coinTrigger.Invoke();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.TryGetComponent<Potion>(out Potion potion))
        {
            _health += 15;
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger(TakeHit);
        _health -= damage;
    }
}
