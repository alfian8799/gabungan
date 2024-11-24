using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator BossAni;
    Collider BossCol;
    public int Health = 100;
    ParticleSystem ShockPS;
    public GameObject Projectile;
    public GameObject Player;
    Rigidbody PRigidbody;
    public int PForce;
    public void Shot()
    {
        BossAni.SetTrigger("HitB");
        Debug.Log("boss hit");
        Health -= 20;

        
        if (Health == 0)
        {
            BossAni.SetTrigger("Done");
        }
    }

    public IEnumerator Jump()
    {
        BossAni.SetTrigger("Jump");
        yield return new WaitForSeconds(2);
        ShockPS.Play();
    }
    public IEnumerator Throw()
    {
        BossAni.SetTrigger("throw");
        yield return new WaitForSeconds(1.5f);
        Projectile.transform.parent = null;
        Projectile.transform.LookAt(Player.transform);
        PRigidbody.AddForce(PRigidbody.transform.forward * PForce);
    }
    // Start is called before the first frame update
    void Start()
    {
        PRigidbody = Projectile.GetComponent<Rigidbody>();
        BossAni = GetComponent<Animator>();
        BossCol = GetComponent<CapsuleCollider>();
        ShockPS = transform.Find("ShockWave").GetChild(0).GetComponent<ParticleSystem>();
        //StartCoroutine(Jump());
        StartCoroutine(Throw());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
