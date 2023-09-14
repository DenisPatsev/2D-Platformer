using UnityEngine;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (SpriteRenderer))]

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Animator _enemyAnimator;
    private int _collisionCount;
    private int _countDivider;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyAnimator = GetComponent<Animator>();

        _collisionCount = 0;
        _countDivider = 2;

        _enemyAnimator.SetBool("isWalk", true);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PathPoint>(out PathPoint pathPoint))
        {
            _spriteRenderer.flipX = true;
            _collisionCount++;
            _speed *= -1;

            if (_collisionCount % _countDivider == 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
