using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed=10;
    public float ShotPeriod=0.2f;
    private float _timer;

    public AudioSource ShotSound;
    public GameObject Flash;
    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if(_timer>ShotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0f;
            Shot();
        }
       
    }
    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        
        ShotSound.Play();
        Flash.SetActive(true);

        Invoke("HideFlash", 0.12f);
    }
    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivete()
    {
        gameObject.SetActive(false);
    }

    public  virtual void AddBullets(int nubmerOfBullets)
    {

    }
}
