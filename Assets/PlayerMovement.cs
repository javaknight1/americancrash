using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ItemController itemController;
    public CharacterController2D characterController;
    float horizontalMove;
    public float runSpeed = 40f;
    private bool jump = false;

    public AudioSource collectSound;

    private void Start()
    {
        collectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            itemController.flipItem(other.gameObject.name);
        }
        else if (other.gameObject.CompareTag("Ship"))
        {
            itemController.flipItem(other.gameObject.name);
        }

    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
