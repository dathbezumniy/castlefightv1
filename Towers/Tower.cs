using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   /* Transform turretTransform;
    float range = 10f;
    public GameObject bulletPrefab;
    Transform bulletPosition;
    Transform pivotPosition;

    float fireCooldown = 0.5f;
    float fireCooldownLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        turretTransform = gameObject.transform.Find("Turret");
        bulletPosition = gameObject.transform.Find("Turret/BulletPosition");
        pivotPosition = gameObject.transform.Find("Turret/PivotPosition");
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if(nearestEnemy == null)
        {
            Debug.Log("No enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - pivotPosition.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        turretTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if(fireCooldownLeft <= 0 && dir.magnitude <= range)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }

    }

    void ShootAt(Enemy e)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletPosition.transform.position, this.transform.rotation);

        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
    }
    */
}
