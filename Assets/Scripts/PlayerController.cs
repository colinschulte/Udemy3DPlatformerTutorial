using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    public CharacterController charCon;

    private CameraController cam;

    private Vector3 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }
    private void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            moveAmount.y += (Physics.gravity.y * Time.fixedDeltaTime);
        }
        else
        {
            moveAmount.y = Physics.gravity.y * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveAmount.y;

        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));

        moveAmount = moveAmount.normalized;
        
        moveAmount.y = yStore;

        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y, moveAmount.z * moveSpeed) * Time.deltaTime);
    }
}
