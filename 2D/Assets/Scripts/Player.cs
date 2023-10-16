using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _coinTrigger;

    private const string TakeHit = "takeDamage";

    private Animator _animator;

    private float _maximalHealth;
    private float _currentHealth;
    private float _healingEffect;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _maximalHealth = 100;
        _currentHealth = _maximalHealth;
        _healingEffect = 15;
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
            _currentHealth += _healingEffect;
            Destroy(collision.gameObject);
            CheckHealth();
        }
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger(TakeHit);
        _currentHealth -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        else if (_currentHealth > _maximalHealth) 
        {
            _currentHealth = _maximalHealth;
        }

        Debug.Log(_currentHealth);
    }
}
