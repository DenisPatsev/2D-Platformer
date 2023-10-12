using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    private const string TakeHit = "takeDamage";

    private Animator _enemyAnimator;

    private float _health;

    private void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _health = 100;
    }

    public void TakeDamage(float damage)
    {
        _enemyAnimator.SetTrigger(TakeHit);
        _health -= damage;
    }
}
