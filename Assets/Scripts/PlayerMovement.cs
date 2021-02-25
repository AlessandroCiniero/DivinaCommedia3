using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController DanteController;

    public float speed = 60f;
    public float gravity = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    private Vector3 velocity;
    private bool isGrounded;
    public static bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        PlayerMovement.active = true;

    }

    // Update is called once per frame
    void Update()

    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!CHEAT CAMBIO SCENA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (Input.GetKey("o") && Input.GetKey("p"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKey("k") && Input.GetKey("l"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }


        if (active)
        {
            isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            DanteController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            DanteController.Move(velocity * Time.deltaTime);
        }

    }
}
