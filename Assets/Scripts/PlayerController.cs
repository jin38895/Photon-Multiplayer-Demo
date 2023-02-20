using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private PhotonView view;
    private float verticalInput;
    private float horizontalInput;
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.forward * speed * verticalInput);
            horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRb.AddForce(Vector3.forward * 10.0f, ForceMode.Impulse);
            }
        }

         
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
