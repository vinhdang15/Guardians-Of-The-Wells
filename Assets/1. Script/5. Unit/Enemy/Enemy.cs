using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : UnitBase
{
    [SerializeField] PathFinder pathFinder;
    private List<Enemy> surroundingEnemies = new List<Enemy>();
    public event Action<Enemy> OnEnemyDeath;

    private void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
    }

    private void OnDisable()
    {
        OnEnemyDeath = null;
    }

    // Get Pathway
    public void GetPathConfigSO(PathConfigSO pathConfigSO)
    {
        pathFinder.PathConfigSO = pathConfigSO;
    }

    public void SetPosInPathWave(int _pathWaveIndex)
    {
        pathFinder.OnSetPosInPathWay(_pathWaveIndex);
    }

    // Move
    public void Move()
    {
        if(CurrentHp == 0) return;
        pathFinder.FollowPath(CurrentSpeed);
    }

    // Pos and Moving direction
    public override void SetMovingDirection()
    {
        if(CurrentPos == null || CurrentHp == 0) return;
        float x = transform.position.x - CurrentPos.x;
        if(x < 0) transform.localScale = new(-1,1);
        else if(x < 0) transform.localScale = new(1,1);
        CurrentPos = transform.position;
    }

    // take damage and Die
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if(CurrentHp == 0)
        {
            OnEnemyDeath?.Invoke(this);
        }
    }

    public IEnumerator ReturnPoolAfterPlayAnimation(UnitPool unitPool)
    {
        yield return new WaitForSeconds(unitAnatation.GetCurrentAnimationLength());
        unitPool.ReturnEnemy(this);
        yield break;
    }

    public override void ResetUnit()
    {
        base.ResetUnit();
    }
}
