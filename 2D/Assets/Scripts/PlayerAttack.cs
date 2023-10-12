using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private const string Attack = "attack";

    private Animator _animator;

    private int _seconds;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _seconds = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            StartCoroutine(Wait(collision, enemy));
        }
    }

    private IEnumerator Wait(Collision2D collision, Enemy enemy)
    {
        _animator.SetTrigger(Attack);

        yield return new WaitForSeconds(_seconds);

        if (Mathf.Abs(collision.transform.position.x - gameObject.transform.position.x) < 2)
        {
            enemy.TakeDamage(_damage);
        }

        yield return new WaitForSeconds(_seconds);
    }
}
