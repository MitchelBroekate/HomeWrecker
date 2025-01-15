using System.Collections;
using UnityEngine;

public class SlingshotShoot : MonoBehaviour
{
    [SerializeField]GameObject projectile;
    [SerializeField]float cooldownTime;
    [SerializeField]int damage;
    [SerializeField]float projectileSpeed;
    PlayerController playerController;
    Transform projectileSpawn;
    bool cooldown;
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        projectileSpawn = transform.GetChild(1);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(!playerController.PlayerLock)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(cooldown) return;

                animator.SetBool("IsAttacking", true);

                audioSource.Play();

                StartCoroutine(ShootTime());
            }
        }
    }

    IEnumerator ShootTime()
    {
        cooldown = true;

        GameObject bullet = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        bullet.GetComponent<StoneDoDamage>().SetDamage(damage);

        yield return new WaitForSeconds(cooldownTime);

        animator.SetBool("IsAttacking", false);

        cooldown = false;
    }

}
