using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] public float jumpForce;
    private Vector3 playerMovementInput;
    [SerializeField] public LayerMask FloorMask;
    [SerializeField] private Rigidbody playerBody;
    public Transform cam;
    [SerializeField] public Transform feetTransform;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(playerMovementInput) * speed;
        transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);
        playerBody.AddForce(MoveVector.x, playerBody.velocity.y, MoveVector.z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(feetTransform.position, 0.1f, FloorMask))
            {
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
