using PurrNet;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    private Transform cameraTransform;
    private Rigidbody rb;

    private Vector3 moveInput;

    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        moveInput = Vector3.zero;
    }


    protected override void OnSpawned()
    {
        cameraTransform = ReferenceManager.GetInstance().cameraTransform;
    }

    public Vector3 GetMovementDirection()
    {
        Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
        cameraRotation = new Vector3(0f, cameraRotation.y, 0f);
        return Vector3.ProjectOnPlane(Quaternion.Euler(cameraRotation) * moveInput, Vector3.up);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Vector3 horizontalVelocity = rb.linearVelocity;
        horizontalVelocity.y = 0f;

        if (Vector3.Dot(horizontalVelocity, movementDirection) <= maxSpeed)
        {
            rb.AddForce(movementDirection * acceleration, ForceMode.Force);
        }
    }

    void Start()
    {
        cameraTransform = ReferenceManager.GetInstance().cameraTransform;
    }

    public void UpdateMoveInput(Vector3 rawInput)
    {
        //if (!isOwner) return;
        Debug.Log(rawInput);
        moveInput = new Vector3(rawInput.x, 0f, rawInput.y);
        Debug.Log("move" + moveInput);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
