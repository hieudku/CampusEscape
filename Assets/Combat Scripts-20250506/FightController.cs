using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    private float speed = 0.04f;
    private float speedinc = 0f;
    private float jumpforce = 5f;
    private float raydistance = 0.0f;

    public PlayerData playerdata;
    public int coffeescore;
    public Toggle Soundtoggle;
    public Toggle Fogtoggle;
    public Toggle PauseButton;

    public AudioSource coffee;
    public AudioSource enemy;
    public AudioSource bmusic;
    public AudioSource GameOverMusic;
    public AudioSource winmusic;
    public AudioSource jumpSound;
    public AudioSource footStepSound;
    public GameObject sword;
    public GameObject mirror;

    public Button Quit;
    public Button Restart;
    public Button Quit1;
    public Button Restart1;

    private bool isMoving = false;
    private float footstepCooldown = 0.37f;
    private float footstepTimer = 0f;

    private bool isPlayingFootstep = false;
    public float footstepInterval = 0.27f;

    public GameObject GameOverPanel;
    public string GameScene;

    float jumpCooldown = 0.2f;
    float lastJumpTime = -10f;

    Rigidbody rb;
    Animator anim1;



    void Start()
    {
        if (string.IsNullOrEmpty(GameScene))
        {
            GameScene = "StartScene";
        }

        rb = GetComponent<Rigidbody>();
        anim1 = GetComponent<Animator>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        anim1.SetBool("Run", false);
        anim1.SetBool("Jump", false);
        anim1.SetBool("Attack", false);

        sword.SetActive(true);
        GameOverPanel.SetActive(false);

        Quit.onClick.AddListener(QuitGame);
        Restart.onClick.AddListener(RestartGame);
        Quit1.onClick.AddListener(QuitGame1);
        Restart1.onClick.AddListener(RestartGame1);
    }

    void QuitGame() => SceneManager.LoadScene(GameScene);
    void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    void QuitGame1() => SceneManager.LoadScene(GameScene);
    void RestartGame1() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Silver"))
        {
            playerdata.score += coffeescore;
            playerdata.coinstogo += coffeescore;
            collision.gameObject.SetActive(false);
            coffee.Play();
        }

        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Skeleton") ||
            collision.gameObject.CompareTag("Giant") ||
            collision.gameObject.CompareTag("Golem"))
        {
            enemy.Play();
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        Debug.Log("You got caught! Game Over.");
        bmusic.mute = true;
        GameOverPanel.SetActive(true);
        GameOverMusic.Play();
        Time.timeScale = 0;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            jumpSound.Play();
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            anim1.SetBool("Jump", true);
            Debug.Log("Jump invoked");
          
}

        if (Input.GetKeyDown("m")) speed = Mathf.Round((speed + speedinc) * 100f) / 100f;
        if (Input.GetKeyDown("n"))
        {
            speed = Mathf.Max(0, Mathf.Round((speed - speedinc) * 100f) / 100f);
        }

        GoldMute(Soundtoggle.isOn);
        RenderSettings.fog = !Fogtoggle.isOn;
    }

    void GoldMute(bool mute)
    {
        coffee.mute = mute;
        enemy.mute = mute;
        bmusic.mute = mute;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * z + camRight * x).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            anim1.SetBool("Attack", false);
            sword.SetActive(true);

            transform.rotation = Quaternion.LookRotation(moveDirection);
            rb.MovePosition(rb.position + moveDirection * speed);


            // Footstep sound cooldown
            footstepTimer += Time.fixedDeltaTime;
            if (footstepTimer >= footstepCooldown)
            {
                footStepSound.Play();
                footstepTimer = 0f;
            }
        }
        else
        {
            anim1.SetBool("Run", false);
            anim1.SetBool("Attack", false);
            sword.SetActive(false);
            footstepTimer = footstepCooldown;
            if (footStepSound.isPlaying)
            {
                footStepSound.Stop();
            }
        }

        mirror.transform.position = this.transform.position;
    }
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    IEnumerator PlayFootstepSound()
    {
        isPlayingFootstep = true;
        footStepSound.Play();
        yield return new WaitForSeconds(footstepInterval);
        isPlayingFootstep = false;
    }
}
