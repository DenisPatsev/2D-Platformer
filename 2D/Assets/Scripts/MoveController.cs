using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private SpriteRenderer _playerRenderer;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRigidbody;

    private float _distance;

    private void Start()
    {
        _playerRenderer = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();

        _distance = 0.5f;

        SetDefaultState();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerAnimator.SetBool("isRun", true);
            _playerRenderer.flipX = true;

            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerAnimator.SetBool("isRun", true);
            _playerRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            SetDefaultState();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _distance);

            if (hit)
            {
                _playerAnimator.SetBool("isJump", true);
                _playerRigidbody.AddForce(Vector2.up * _jumpForce);
            }
        }
        else
        {
            _playerAnimator.SetBool("isJump", false);
        }
    }

    private void SetDefaultState()
    {
        _playerAnimator.SetBool("isRun", false);
        _playerAnimator.SetBool("isJump", false);
    }
}
