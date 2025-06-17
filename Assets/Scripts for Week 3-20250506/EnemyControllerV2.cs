using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerV2 : MonoBehaviour
{
    Animator anim;
    public GameObject target;
    public AudioSource impact;
    NavMeshAgent agent;
    int hit = 0;
    public float walkingspeed;
    public float runningspeed;
    public bool Chaseonly;
    public PlayerData playerdata;

    enum STATE { IDLE, WANDER, ATTACK, CHASE, DEAD }
    STATE state = STATE.IDLE;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player");
        if (target == null)
        {
            Debug.LogWarning($"{gameObject.name} could not find the Player. Disabling EnemyControllerV2.");
            this.enabled = false;
            return;
        }

        if (this.gameObject.tag == "Chaser")
        {
            playerdata.Chasers = playerdata.Chasers + 1;
        }
        if (this.gameObject.tag == "Skeleton")
        {
            playerdata.Skeletons = playerdata.Skeletons + 1;
        }
        if (this.gameObject.tag == "Giant")
        {
            playerdata.Giants = playerdata.Giants + 1;
        }
        if (this.gameObject.tag == "Zombie")
        {
            playerdata.Zombies = playerdata.Zombies + 1;
        }
    }
    void TurnoffTriggers()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
    }
    float DistancetoPlayer()
    {
        return Vector3.Distance(target.transform.position, this.transform.position);
    }
    bool CanSeePlayer()
    {
        if (DistancetoPlayer() < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool ForgetPlayer()
    {
        if (DistancetoPlayer() > 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        playerdata.Golemdead = false;
        if (other.gameObject.tag == "Sword")
        {
            if (hit == 0)
            {
                if (this.gameObject.tag == "Chaser")
                {
                    playerdata.Chasers = playerdata.Chasers - 1;
                }
                if (this.gameObject.tag == "Skeleton")
                {
                    playerdata.Skeletons = playerdata.Skeletons - 1;
                }
                if (this.gameObject.tag == "Giant")
                {
                    playerdata.Giants = playerdata.Giants - 1;
                }
                if (this.gameObject.tag == "Zombie")
                {
                    playerdata.Zombies = playerdata.Zombies - 1;
                }
                if (this.gameObject.tag == "Golem")
                {
                    playerdata.Golemdead = true;
                }
            }
            hit = 1;
            
            impact.Play();
            Debug.Log("Chaser hit");
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -100)
        {
            playerdata.Chasers = playerdata.Chasers - 1;
            Destroy(this.gameObject);
        }
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
            return;
        }
        switch (state)
        {
            

            case STATE.IDLE:
                if (Chaseonly)
                {
                    state = STATE.CHASE;
                    break;
                }
                if (hit > 0)
                {
                    state = STATE.DEAD; 
                }
                if (CanSeePlayer())
                {
                    state = STATE.CHASE;
                }
                else if (Random.Range(0, 5000) < 5)
                {
                    state = STATE.WANDER;
                }
                break;

            case STATE.WANDER:
                if (!agent.hasPath)
                {
                    agent.speed = walkingspeed;
                    anim.SetBool("Walk", true);
                    float newX = this.transform.position.x + Random.Range(-5, 5);
                    float newZ = this.transform.position.z + Random.Range(-5, 5);
                    // float newY = Terrain.activeTerrain.SampleHeight(new Vector3(newX, 0, newZ));
                    float newY = 0f;
                    Vector3 dest = new Vector3(newX, newY, newZ);
                    agent.SetDestination(dest);
                    agent.stoppingDistance = 2f;
                    
                    
                }
                if (hit > 0)
                {
                    state = STATE.DEAD;
                }
                if (CanSeePlayer())
                {
                    Debug.Log("Can see player");

                    state = STATE.CHASE;
                }
                else if (Random.Range(0, 5000) < 5)
                {
                    state = STATE.IDLE;
                    TurnoffTriggers();
                    agent.ResetPath();
                }
                break;

            case STATE.CHASE:
                                
                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 2;
                TurnoffTriggers();
                agent.speed = runningspeed;
                anim.SetBool("Run", true);
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    state = STATE.ATTACK;
                }
                if (hit > 0)
                {
                    state = STATE.DEAD;
                }
                if (ForgetPlayer() && !Chaseonly)
                {
                    state = STATE.WANDER;
                    agent.ResetPath();
                }
                break;

            case STATE.ATTACK:

                if (DistancetoPlayer() <= agent.stoppingDistance + 0.5f)
                {
                    Debug.Log("Player caught - Game Over!");

                    // Optional: freeze player
                    Time.timeScale = 0;

                    // Show Game Over Panel (must assign from inspector)
                    FightController fc = target.GetComponent<FightController>();
                    if (fc != null)
                    {
                        // Show Game Over UI
                        if (fc.GameOverPanel != null)
                            fc.GameOverPanel.SetActive(true);

                        // Play game over music
                        if (fc.GameOverMusic != null)
                            fc.GameOverMusic.Play();

                        // Mute background music
                        if (fc.bmusic != null)
                            fc.bmusic.mute = true;
                    }
                    else
                    {
                        Debug.LogWarning("Could not find GameOverPanel from FightController.");
                    }

                    // Disable player
                    target.SetActive(false);
                }

                break;

            case STATE.DEAD:

                TurnoffTriggers();
                anim.SetBool("Die", true);



                // hit = 1;
                // Destroy(this.gameObject, 5f);
                Debug.Log("Case DEAD");
                
                Destroy(this.gameObject,5f);
                // this.GetComponent<Sink>().StartSink();
                break;


        }
    }
}