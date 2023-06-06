using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text HealthText;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _extraJumpValue;
    [SerializeField] private float _checkRadius;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _health;
    private Vector2 _moveInput;
    private bool _facingRight = true;
    private Rigidbody2D _rigidbody2D;

    private float _extraJump;
    private float _speed = 5f;
    private bool _isGround;
    private const int MAX_HEALTH = 3;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = MAX_HEALTH;
        HealthText.text = _health.ToString();
        
    }


    void Update()
    {
        Jump();
        Move();
        Flip();
    }

    private void Move()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_moveInput.x * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (_isGround == true)
        {
            _extraJump = _extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _extraJump > 0)
        {
            _rigidbody2D.velocity = Vector2.up * _extraJump;
            _extraJump--;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && _extraJump == 0 && _isGround == true)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }

        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
    }

    private async void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.GetComponent<EnemyMovement>())
        {
            _health -= 1;
            HealthText.text = _health.ToString();
           
        }

        if (_health < 1)
        {
            Destroy(gameObject);
            await Task.Delay(3000);
            CoinPick.Coins = 0;
            SceneManager.LoadSceneAsync(0);
        }
    }

    private void Flip()
    {
        if (_moveInput.x > 0 && _facingRight == false || _moveInput.x < 0 && _facingRight == true)
        {
            var transform1 = transform;
            Vector3 theScale = transform1.localScale;
            theScale.x *= -1f;
            transform1.localScale = theScale;

            _facingRight = !_facingRight;
        }
    }
}