using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControllerMovement : MonoBehaviour
{
   
    public GameManager gameManager;
    public SpawnManager spawnManager;
    public PlayerScript playerScript;

    private Vector3 velocity;
    private Vector3 PlayerMovementInput;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float turnSpeed;
    private Animator animator;





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

       

    }

    void Update()
    {
        PlayerMovementInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        if (!playerScript.isPlayerAlive)
        {
            return;
           
        }

        MovePlayer();
        animator.SetBool("isMoving", PlayerMovementInput != Vector3.zero && Controller.isGrounded);


    }


    void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        transform.Rotate(Vector3.up, turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Controller.isGrounded)
        {             
                        
            velocity.y = -1f;
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                               
                velocity.y = jumpForce;
              
            }
        }
       else
       {
            velocity.y -= gravity * -2f * Time.deltaTime;
            

       }

        Controller.Move(MoveVector * speed * Time.deltaTime);
        Controller.Move(velocity * Time.deltaTime);
    }


   
    }

       
    
    

