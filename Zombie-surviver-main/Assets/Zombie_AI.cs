using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WaypointsFree;

enum ENEMY_STATE
{
    STATE_PATROLLING,
    STATE_TRACKING,
    STATE_ATTACKING,
    STATE_WATING,
    STATE_DEAD
};
public class Zombie_AI : MonoBehaviour
{
    ENEMY_STATE State;
    public Transform Player;
    public float DistForTracking;
    public float DistForAttacking;
    public NavMeshAgent Agent;
    Animator ZomAni;
    Collider ZomCol;
    public string[] FallTriggers;
    private bool SoundOn = true;

    //time
    public float  AttackF;
    private float Timer = 0.0f;
    private float TimeSinceLastAttack = 0.0f;
    private bool IsAlive = true;

    //sound
    private AudioSource Audio;
    public AudioClip[] IdleSounds;
    public AudioClip[] AttackSound;
    public int IdleSoundDelay = 10;
    WaypointsTraveler WaypointScript;



    void CallAudio()
    {
        Invoke("PlayIdleSound",IdleSoundDelay);
    }
    void PlayIdleSound()
    {
        int RandomNumberI = Random.Range(0, IdleSounds.Length);
        Audio.clip = IdleSounds[RandomNumberI];
        
        
            if (State == ENEMY_STATE.STATE_PATROLLING)
            {
                Audio.Play();
            }
        
        
        CallAudio();
    }

    public void Shot()
    {
        int RandomNumberFall = Random.Range(0, FallTriggers.Length);
        Agent.isStopped = true;
        string TriggerName = FallTriggers[RandomNumberFall];
        
        ZomAni.SetTrigger(TriggerName);
        Debug.Log("RandomNumberFall " + RandomNumberFall);
        Debug.Log("FallTriggers Length " + FallTriggers.Length);
        State = ENEMY_STATE.STATE_DEAD;
       
    }
    
    void UpdateState()
    {
        float distance = Vector3.Distance(Player.position, transform.position);
        
        if (State == ENEMY_STATE.STATE_PATROLLING)
        {
            
            //Debug.Log("distance to player = " + distance);
            if (distance < DistForTracking)
            {
                State = ENEMY_STATE.STATE_TRACKING;
                WaypointScript.enabled = false;
            }
        }
        if (State == ENEMY_STATE.STATE_TRACKING)
        {
           // Debug.Log("state if treackigng");
            Agent.SetDestination(Player.position);
            if (distance < DistForAttacking)
            {
                State = ENEMY_STATE.STATE_ATTACKING;
               
            }
        }
        if (State == ENEMY_STATE.STATE_ATTACKING)
        {
            
            ZomAni.SetTrigger("attack");
            int RandomNumberA = Random.Range(0, AttackSound.Length);
            Agent.SetDestination(Player.position);
            State = ENEMY_STATE.STATE_WATING;
            Audio.clip = AttackSound[RandomNumberA];
            Audio.Play();
            Timer = Time.deltaTime; //change in time since last frame
            if(IsAlive == true)
            {
                Player.gameObject.GetComponent<PlayerC>().hit();
            }
        }
        if (State == ENEMY_STATE.STATE_WATING)
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > AttackF)
            {
                if (distance >= DistForAttacking)
                {
                    State = ENEMY_STATE.STATE_TRACKING;
                }
                if (distance < DistForAttacking)
                {
                    State = ENEMY_STATE.STATE_ATTACKING;
                }
            }
        }
        if (State == ENEMY_STATE.STATE_DEAD) 
        {
            WaypointScript.enabled = false;
            ZomCol.enabled = false;
            IsAlive = false;
            SoundOn = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        State = ENEMY_STATE.STATE_PATROLLING;
        WaypointScript = GetComponent<WaypointsTraveler>();
        ZomAni = GetComponent<Animator>();
        ZomCol = GetComponent<CapsuleCollider>();
        Audio = GetComponent<AudioSource>();
        CallAudio();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}
