using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.PackageManager;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kcontroller : MonoBehaviour
{
    //public float speed;
    //public float speedinc;
    private float speed = 0.1f;
    private float speedinc = 0f;
    private float jumpforce = 300f;
    //public float jumpforce;
    private float raydistance = 0.0f;
    public PlayerData playerdata;
    public int silverscore;
    public int damage;
    public int chaserdamage;
    public int skeletondamage;
    public int giantdamage;
    public int zombiedamage;
    public int rehealth;
    public Toggle Soundtoggle;
    public Toggle Fogtoggle;
    public Toggle PauseButton;
    public AudioSource silver;
    public AudioSource Gold;
    public AudioSource Potion;
    public AudioSource enemy;
    public AudioSource bmusic;
    public AudioSource swordsound;
    public AudioSource GameOverMusic;
    public GameObject mirror;
    public Button Quit;
    public Button Restart;
    public GameObject GameOverPanel;
    public string GameScene;

    Rigidbody rb;
    Animator anim1;
    int soundplayed = 0;
    int GameOver = 0;



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
        bmusic.Play();
        GameOverPanel.SetActive(false);
        AudioListener.volume = 1;

        //set up button listeners
        Button btn = Quit.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);

        Button btn1 = Restart.GetComponent<Button>();
        btn1.onClick.AddListener(RestartGame);

    }
    void QuitGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    void RestartGame()
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
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Chaser" || collision.gameObject.tag == "Skeleton"
            || collision.gameObject.tag == "Giant")
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

            enemy.Play();

            if (playerdata.health <= 0)
            {
                bmusic.mute = true;
                GameOverMusic.Play();
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
                this.gameObject.SetActive(false);
                playerdata.playerdead = true;
                PauseButton.isOn = true;
            }
        }
        if (collision.gameObject.tag == "Gold")
        {
            if (playerdata.health < 100)
            {
                playerdata.health = playerdata.health + rehealth;

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
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Plus Key Pressed");
            if (speed < 0.3)
            {
                speed = speed + speedinc;
                speed = (float)System.Math.Round(speed, 2);
                //playerdata.force = speed;
            }
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
        if(playerdata.health > 0)
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
        if (playerdata.LevelUp == true && soundplayed == 0)
        {

        Debug.Log("changeplayer update");
        swordsound.Play();
        soundplayed = 1;

        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (!Input.anyKey)
        {
            //Debug.Log("No key pressed");
            anim1.SetBool("Jump", false);
            anim1.SetBool("Run", false);
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            Debug.Log("Left Key pressed");
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            anim1.SetBool("Run", true);
            anim1.SetBool("Jump", false);
            
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.anyKey)
        {
         
            transform.position += new Vector3(x * speed, 0, z * speed);
            mirror.transform.position = this.transform.position;
        }
    }
    bool IsGrounded()
    {
        //Debug.Log(capsule.height);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -Vector3.up,out hitInfo,  0.2f))
        
        //(Physics.SphereCast(transform.position, capsule.radius / 2, Vector3.down, out hitInfo, raydistance))
        {
            Debug.Log("Grounded");
            return true;
        }
        Debug.Log("Not Grounded");
        return false;
    }
}
