using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private const string Attack = "attack";

    private Animator _animator;

    private int _seconds;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _seconds = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(StartAttack(collision, player));
        }
    }

    private IEnumerator StartAttack(Collision2D collision, Player player)
    {
        _animator.SetTrigger(Attack);

        yield return new WaitForSeconds(_seconds);

        if (Mathf.Abs(collision.transform.position.x - gameObject.transform.position.x) < 2)
        {
            player.TakeDamage(_damage);
        }

        yield return new WaitForSeconds(_seconds);
    }
}
