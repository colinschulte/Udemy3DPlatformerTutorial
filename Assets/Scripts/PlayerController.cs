using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed, jumpForce, gravityScale;
    private float yStore;

    public CharacterController charCon;

    private CameraController cam;

    private Vector3 moveAmount;

    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }
    private void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            moveAmount.y += (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);
        }
        else
        {
            moveAmount.y = Physics.gravity.y * gravityScale * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveAmount.y;

        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));
        moveAmount.y = 0f;
        moveAmount = moveAmount.normalized;

        if (moveAmount.magnitude > 0.1f)
        {
            if(moveAmount != Vector3.zero)
            {
                Quaternion newRot = Quaternion.LookRotation(moveAmount);

                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotateSpeed * Time.deltaTime);
            }
        }

        moveAmount.y = yStore;

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump")){
                moveAmount.y = jumpForce;
            }
        }

        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y, moveAmount.z * moveSpeed) * Time.deltaTime);
    }
}
