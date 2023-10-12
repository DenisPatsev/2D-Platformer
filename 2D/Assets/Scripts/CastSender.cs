using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class CastSender : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _enemyRigidbody;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private UnityEvent _isFound;
    [SerializeField] private UnityEvent _isNotFound;

    private RaycastHit2D[] _rightCastResults = new RaycastHit2D[5];
    private RaycastHit2D[] _leftCastResults = new RaycastHit2D[5];

    private SpriteRenderer _renderer;

    private float _castDistance;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _castDistance = 8;
    }

    private void FixedUpdate()
    {
        SendRigidbodyCast(transform.right, _rightCastResults, 2, false);
        SendRigidbodyCast(transform.right * -1, _leftCastResults, -2, true);
    }

    private void SendRigidbodyCast(Vector3 direction, RaycastHit2D[] results, int speed, bool isNeedFlip)
    {
        var CollisionCount = _enemyRigidbody.Cast(direction, _filter, results, _castDistance);

        if (CollisionCount > 0)
        {
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].collider.TryGetComponent<Player>(out Player player))
                {
                    _isFound.Invoke();
                    float distance = results[i].transform.position.x - transform.position.x;

                    if (distance < 0)
                    {
                        _renderer.flipX = true;
                    }
                    else
                    {
                        _renderer.flipX = false;
                    }

                    transform.Translate(Time.deltaTime * speed, 0, 0);
                }
                else
                {
                    _isNotFound.Invoke();
                }
            }
        }
    }
}
