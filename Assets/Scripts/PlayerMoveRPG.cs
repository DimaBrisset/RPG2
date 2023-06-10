
using UnityEngine;

public class PlayerMoveRPG  : MonoBehaviour
{
    public float joystickSpeed = 5f; // Скорость передвижения персонажа с помощью джойстика
    public float keyboardSpeed = 10f; // Скорость передвижения персонажа с помощью клавиатуры

    private Joystick joystick; // Ссылка на компонент джойстика
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D персонажа
    private Vector2 _moveInput;
    private bool _facingRight = true;
    

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>(); // Найти джойстик в сцене
        rb = GetComponent<Rigidbody2D>(); // Получить компонент Rigidbody2D персонажа
    }

    private void Update()
    {
        
        Flip();
        PlayerMoved();
    }

    private void PlayerMoved()
    {
  
        var joystickMoveHorizontal = joystick.Horizontal;
        var joystickMoveVertical = joystick.Vertical;

     
        var keyboardMoveHorizontal = Input.GetAxis("Horizontal");
        var keyboardMoveVertical = Input.GetAxis("Vertical");

    
        var joystickMovement = new Vector2(joystickMoveHorizontal, joystickMoveVertical);

     
        var keyboardMovement = new Vector2(keyboardMoveHorizontal, keyboardMoveVertical);

      
        joystickMovement = joystickMovement.normalized * joystickSpeed;
        keyboardMovement = keyboardMovement.normalized * keyboardSpeed;

     
        var movement = joystickMovement + keyboardMovement;

        
        rb.velocity = movement;
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