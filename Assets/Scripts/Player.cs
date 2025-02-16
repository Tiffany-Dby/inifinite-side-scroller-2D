using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject player;
    private bool isGrounded;
    private float jumpForce = 6;

    private Rigidbody playerRigidBody;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpOnKeyDown();
        }

        if (player.transform.position.y < 35)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void JumpOnKeyDown()
    {
        playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Start"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("Platform"))
        {
            FindAnyObjectByType<Score>().UpdateScore();
        } 
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
