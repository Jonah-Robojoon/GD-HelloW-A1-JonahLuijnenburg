using UnityEngine;

public class CharecterControlerMovement : MonoBehaviour
{
    private Animator myAnimator;


    public float moveSpeed = 0.01f;
    public float rotationSpeed = 0.2f;
    public float jumpForce = 308f;
    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        myAnimator= GetComponent<Animator>();
        characterController = GetComponent<CharacterController>(); //refrentie
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0);

        characterController.Move(transform.forward * moveSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            myAnimator.SetFloat("speed", Input.GetAxisRaw("Vertical"));
        }
        else
        {
            myAnimator.SetFloat("speed", 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            characterController.Move(transform.up * 1 * jumpForce * Time.deltaTime);
            //myAnimator.SetFloat("jump", 1);
        }
    }
}
