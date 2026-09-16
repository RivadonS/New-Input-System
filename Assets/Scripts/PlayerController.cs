using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerControls controls;
    private Vector2 moveInput;

    [Header("Settings")]
    public float moveSpeed = 5f;

    private void Awake()
    {
        // สร้าง instance ของ PlayerControls
        controls = new PlayerControls();

        // ขยับ Joystick
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();

        // ปล่อย Joystick
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Interact.performed += ctx => InteractAction();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        { 
            transform.forward = moveDirection;
        }
    }

    private void InteractAction()
    {
        Debug.Log("Player interacted with an object!");
    }
}
