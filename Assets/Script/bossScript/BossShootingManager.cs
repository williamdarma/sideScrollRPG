using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPos;
    [SerializeField] int totalPool = 10;
    [SerializeField] List<GameObject> listBullet = new List<GameObject>();
    void initBullet()
    {
        for (int i = 0; i < totalPool; i++)
        {
            GameObject temp = Instantiate(bulletPrefab);
            listBullet.Add(temp);
            temp.SetActive(false);
        }
    }
    GameObject poolBullet()
    {
        GameObject bullet = null;
        foreach (GameObject go in listBullet)
        {
            if (!go.activeInHierarchy)
            {
                bullet = go;
                break;
            }
        }
        return bullet;
    }
    public void Shoot(float facingDir)
    {
        GameObject newBullet = poolBullet();


        newBullet.transform.position = bulletSpawnPos.transform.position;
        newBullet.transform.rotation = Quaternion.identity;
        if (facingDir < 0)
        {
            newBullet.GetComponent<bullet>().setNegativeSpeed();
        }
        newBullet.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        initBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
