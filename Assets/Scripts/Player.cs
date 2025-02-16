using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject player;
    private bool isGrounded;
    [SerializeField] private float jumpForce = 6;

    static string GAME_SCENE = "GameScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpOnKeyDown();
        }

        if (player.transform.position.x < -15)
        {
            Debug.Log("Ici");
            SceneManager.LoadScene(GAME_SCENE);
        }
    }

    void JumpOnKeyDown()
    {
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            isGrounded = true;
        }
    }
}
