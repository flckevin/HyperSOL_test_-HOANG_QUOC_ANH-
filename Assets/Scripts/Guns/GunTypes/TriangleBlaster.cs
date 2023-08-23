using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBlaster : GunRoot
{
    public float[] zRotation;
    public Vector2[] positionOffSet;
    
    public override void GunBehaviour()
    {
        for (int i = 0; i < positionOffSet.Length; i++) 
        {
            PoolManager.Instance.bullets[PoolManager.Instance.BulletID].transform.position = new Vector3(this.transform.position.x + positionOffSet[i].x,
                                                                                                             this.transform.position.y + positionOffSet[i].y,
                                                                                                             this.transform.position.z);
            
            PoolManager.Instance.bullets[PoolManager.Instance.BulletID].transform.eulerAngles = new Vector3(0, 0, zRotation[i]);
            PoolManager.Instance.bullets[PoolManager.Instance.BulletID].gameObject.SetActive(true);
            PoolManager.Instance.BulletID++;
            PoolManager.Instance.bullets[PoolManager.Instance.BulletID].name = gunStats.damage.ToString();
        }

        _audioSrc.PlayOneShot(gunStats.gunClip, 1);
       
    }
}
