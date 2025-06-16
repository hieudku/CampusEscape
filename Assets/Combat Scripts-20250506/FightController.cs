using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    private float speed = 0.04f;
    private float speedinc = 0f;
    //public float speed;
    //public float speedinc;
    private float jumpforce = 300f;
    //public float jumpforce;
    private float raydistance = 0.0f;
    //public float raydistance;
    public PlayerData playerdata;
    public int silverscore;
    public int damage;
    public int chaserdamage;
    public int skeletondamage;
    public int giantdamage;
    public int zombiedamage;
    public int golemdamage;
    public int rehealth;
    public Toggle Soundtoggle;
    public Toggle Fogtoggle;
    public Toggle PauseButton;
    public AudioSource silver;
    public AudioSource Gold;
    public AudioSource Potion;
    public AudioSource enemy;
    public AudioSource bmusic;
    public AudioSource GameOverMusic;
    public AudioSource winmusic;
    public GameObject sword;
    public GameObject mirror;
    public Button Quit;
    public Button Restart;
    public Button Quit1;
    public Button Restart1;

    public GameObject GameOverPanel;
    public string GameScene;
    int GameOver = 0;
    bool golemdead;



    //public PlayerData playerdata;
    Rigidbody rb;
    Animator anim1;
    //CapsuleCollider capsule;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim1 = this.GetComponent<Animator>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        //capsule = this.GetComponent<CapsuleCollider>();
        //playerdata.force = speed;
        Debug.Log(speed);
        //Debug.Log(playerdata.force);
        anim1.SetBool("Run", false);
        anim1.SetBool("Jump", false);
        anim1.SetBool("Attack", false);

        sword.SetActive(true);
        GameOverPanel.SetActive(false);

        golemdead = false;

        //set up button listeners
        Button btn = Quit.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);

        Button btn1 = Restart.GetComponent<Button>();
        btn1.onClick.AddListener(RestartGame);

        Button btn2 = Quit1.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame1);

        Button btn3 = Restart1.GetComponent<Button>();
        btn3.onClick.AddListener(RestartGame1);
    }

    void QuitGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    void QuitGame1()
    {
        SceneManager.LoadScene(GameScene);
    }
    void RestartGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Silver")
        {
            playerdata.score = playerdata.score + silverscore;
            playerdata.coinstogo = playerdata.coinstogo + silverscore;
            collision.gameObject.SetActive(false);
            silver.Play();
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Chaser" || 
            collision.gameObject.tag == "Skeleton" || collision.gameObject.tag == "Giant" 
            || collision.gameObject.tag == "Golem")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                playerdata.health = playerdata.health - damage;
            }
            if (collision.gameObject.tag == "Chaser")
            {
                playerdata.health = playerdata.health - chaserdamage;
            }
            if (collision.gameObject.tag == "Skeleton")
            {
                playerdata.health = playerdata.health - skeletondamage;
            }
            if (collision.gameObject.tag == "Giant")
            {
                playerdata.health = playerdata.health - giantdamage;
            }
            if (collision.gameObject.tag == "Zombie")
            {
                playerdata.health = playerdata.health - zombiedamage;
            }
            if (collision.gameObject.tag == "Golem")
            {
                playerdata.health = playerdata.health - golemdamage;
            }
            enemy.Play();

            if (playerdata.health <= 0)
            {
                bmusic.mute = true;
                GameOverPanel.SetActive(true);
                GameOverMusic.Play();
                Time.timeScale = 0;
                this.gameObject.SetActive(false);
                playerdata.playerdead = true;
                Soundtoggle.isOn = true;


            }
        }
        
        if (collision.gameObject.tag == "Gold")
        {
            if (playerdata.health < 100)
            {
                playerdata.health = playerdata.health + rehealth;
                if (playerdata.health > 100)
                {
                    playerdata.health = 100;
                }
            }
            collision.gameObject.SetActive(false);
            Gold.Play();
        }
        if (collision.gameObject.tag == "Potion")
        {
            playerdata.health = 100;
            collision.gameObject.SetActive(false);
            Potion.Play();

        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0, jumpforce, 0);
            anim1.SetBool("Jump", true);
            Debug.Log("Jump Invoked");

        }
        
        if (playerdata.Golemdead && !golemdead)
        {
            golemdead = true;
            Debug.Log("Golem Dead");
            winmusic.Play();
            PauseButton.isOn = true;
        }

        
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Plus Key Pressed");
            speed = speed + speedinc;
            speed = (float)System.Math.Round(speed, 2);
            //playerdata.force = speed;
        }
        if (Input.GetKeyDown("n"))
        {
            Debug.Log("Minus Key Pressed");
            speed = speed - speedinc;
            speed = (float)System.Math.Round(speed, 2);
            if (speed <= 0)
            {
                speed = 0;
            }
            // playerdata.force = speed;
        }
        if (Soundtoggle.isOn)
        {
            Gold.mute = true;
            silver.mute = true;
            enemy.mute = true;
            bmusic.mute = true;
        }
        else
        {
            Gold.mute = false;
            silver.mute = false;
            enemy.mute = false;
            if (playerdata.health > 0)
            {
                bmusic.mute = false;
            }
        }
        if (Fogtoggle.isOn)
        {
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.fog = true;
        }
    }   
    void FixedUpdate()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Get camera's forward and right vectors (flattened on Y axis)
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Movement direction relative to camera
        Vector3 moveDirection = (camForward * z + camRight * x).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            anim1.SetBool("Attack", false);
            sword.SetActive(true);

            // Rotate to face move direction
            transform.rotation = Quaternion.LookRotation(moveDirection);

            // Move player
            transform.position += moveDirection * speed;
        }
        else
        {
            anim1.SetBool("Run", false);
            anim1.SetBool("Attack", false);
            sword.SetActive(false);
        }

        // update mirror position
        mirror.transform.position = this.transform.position;

    }
    bool IsGrounded()
    {
        //Debug.Log(capsule.height);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 0.2f))

        //(Physics.SphereCast(transform.position, capsule.radius / 2, Vector3.down, out hitInfo, raydistance))
        {
            Debug.Log("Grounded");
            return true;
        }
        Debug.Log("Not Grounded");
        return false;
    }
}
