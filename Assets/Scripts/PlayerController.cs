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

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), 
        //                                 transform.position.y, 
        //                                 transform.position.z + (Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));

        moveAmount.y = 0f;

        moveAmount = moveAmount.normalized;

        charCon.Move(moveAmount * moveSpeed * Time.deltaTime);
    }
}
