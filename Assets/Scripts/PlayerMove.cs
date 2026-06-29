using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private PlayerControl controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 8f;

    void Awake()
    {
        controls = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = moveInput * moveSpeed;
    }
    
}
