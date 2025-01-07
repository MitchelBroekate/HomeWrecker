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

    void Start()
    {
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

        cooldown = false;
    }

}
