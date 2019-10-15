using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float bulletSpeed;
    [SerializeField] float destroyTime;
    [SerializeField] int damageAmount;
    private float curTime;


    void Update()
    {
        //destroy bullet is destroy time is up
        if (curTime > destroyTime)
        {
            Destroy(this.gameObject);
        }
        curTime += Time.deltaTime;
    }


    public float getBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetBulletSpeed(float amt)
    {
        bulletSpeed = amt;
    }

    public float getDestroyTime()
    {
        return destroyTime;
    }

    public void SetDestroyTime(float amt)
    {
        destroyTime = amt;
    }

    // perform trigger checks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    //Debug.Log("Hit enemy");
        //    collision.gameObject.GetComponent<Enemy>().DealDamage(damageAmount);
        //    Destroy(this.gameObject);
        //}

        //if (collision.gameObject.tag == "Item" && collision.gameObject.name == "crate_orig")
        //{
        //    collision.gameObject.GetComponent<Item>().decreaseDurability(1);
        //    if (collision.gameObject.GetComponent<Item>().getCurDurability() == 0)
        //    {
        //        Vector3 loc = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);
        //        collision.gameObject.GetComponent<ItemManager>().SpawnRandomItem(loc);
        //        Destroy(collision.gameObject);
        //    }
        //    Destroy(this.gameObject);

        //}
    }
}
