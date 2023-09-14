using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MushroomMotion : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _mushroomRigidbody;
    [SerializeField] private ContactFilter2D _filter;

    private Animator _animator;

    private RaycastHit2D[] _results = new RaycastHit2D[1];

    private float _castDistance;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _castDistance = 8;
    }

    private void FixedUpdate()
    {
        var collisionCount = _mushroomRigidbody.Cast(transform.right, _filter, _results, _castDistance);

        if (collisionCount > 0)
        {
            for (int i = 0; i < _results.Length; i++)
            {
                if (_results[i])
                {
                    _animator.SetBool("isRun", true);
                    transform.Translate(Time.deltaTime, 0, 0);
                }
            }
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }
}
