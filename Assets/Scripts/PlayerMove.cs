using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class PlayerMove : MonoBehaviour
{
    private PlayerControl Controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 8f;

    void Awake()
    {
        Controls = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
    }

    void Enable()
    {
        
    }
    
}
