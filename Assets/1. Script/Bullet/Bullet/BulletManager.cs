using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;
    [SerializeField] List<BulletBase> activeBullets = new List<BulletBase>();

    // private void Awake()
    // {
    //     LoadComponents();
    // }

    public void PrepareGame()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        bulletPool = FindObjectOfType<BulletPool>();
    }

    private void Update()
    {
        if(activeBullets.Count == 0) return;
        foreach(var bullet in activeBullets)
        {
            bullet.MoveToTarget();
        }
    }

    public void SpawnBullet(string bulletType, Vector2 initPos, float spawnBulletDirection, UnitBase _enemy, TowerPresenter towerPresenter)
    {
        BulletBase bullet = bulletPool.GetBullet(bulletType, initPos);
        bullet.InitBulletParent(towerPresenter);
        bullet.InitBulletTarget(_enemy);
        bullet.SetBulletInitAngle(spawnBulletDirection);
        bullet.OnFinishBulletAnimation += HandleFinishBulletAnimation;
        activeBullets.Add(bullet);
    }
    
    private void HandleFinishBulletAnimation(BulletBase bullet)
    {
        activeBullets.Remove(bullet);
        bulletPool.ReturnBullet(bullet);
    }
}
