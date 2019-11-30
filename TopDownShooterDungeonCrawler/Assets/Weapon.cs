using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] GameManager gm;
    /*
     
        Things to add:
        - time to reload gun
        - gun upgrades
        - gun damage
        - durability

         
    */

    //Bullet variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform[] firePoint;
    //[SerializeField] float bulletSpeed;
    //[SerializeField] float destroyTime;

    //Gun variables
    [SerializeField] string gunName;
    private int curAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] bool canShoot;
    [SerializeField] float reloadTime;
    [SerializeField] int amtDamage;
    [SerializeField] int durability;

    public int i = 0;

    /*
    public Gun(string name, int max, float relTime) {
        gunName = name;
        maxAmmo = max;
        reloadTime = relTime;
    }
    */
    void Start()
    {
        curAmmo = maxAmmo;
        canShoot = true;
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //gm.UpdateAmmo(curAmmo);

    }

    public void Shoot()
    {
        // If there is still ammo.... SHOOT!
        if (curAmmo > 0 && canShoot)
        {
            if (i == firePoint.Length - 1)
            {
                i = 0;
            }
            else if (i < firePoint.Length)
            {
                i++;
            }
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

            Vector2 direction = target - myPos;
            //Debug.DrawRay(myPos, target, Color.magenta);
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f);

            GameObject projectile = Instantiate(bulletPrefab, firePoint[i].position, transform.rotation);
            
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<Projectile>().getBulletSpeed();
            curAmmo--;




            //Debug.Log("curAmmo: " + curAmmo);
        }
        // Else go to reloading...
        else
        {
            canShoot = false;
            StartCoroutine(ReloadGun());
        }
    }
    IEnumerator ReloadGun()
    {
        //gm.UpdateAmmo(-1);
        yield return new WaitForSeconds(reloadTime);
        //gm.UpdateAmmo(maxAmmo);
        curAmmo = maxAmmo;
        canShoot = true;
    }

    public int getCurAmmo()
    {
        return curAmmo;
    }
}
