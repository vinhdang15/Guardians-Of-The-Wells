using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    public string   UnitType        { get; set;}
    public string   UnitName => gameObject.name.Trim().ToLower();        
    public int      MaxHP           { get; set;}
    public float    Speed           { get; set;}
    public int      Damage          { get; set;}
    public int      Gold            { get; set;}
    public string   SpecialAbility  { get; set;}
    public float    CurrentHp       { get; set;}
    public float    CurrentSpeed    { get; set;}
    public bool     IsUnderEffect   { get; set;}
    protected Vector2 CurrentPos    { get; set;}
    [SerializeField] HealthBar healthBar;
    public Dictionary<string, IEffect> underEffect = new Dictionary<string, IEffect>();

    // Animation
    public UnitAnimation unitAnatation;

    #region INIT UNIT
    public virtual void InItUnit(UnitData _unitData)
    {
        InitUnitData(_unitData);
        SetupCurrentHp();
        SetDefaultSpeed();
    }
    public virtual void InitUnitData(UnitData _unitData)
    {
        UnitType        = _unitData.unitType;
        MaxHP           = _unitData.maxHP;
        Speed           = _unitData.speed;
        Damage          = _unitData.damage;
        Gold            = _unitData.gold;
        SpecialAbility  = _unitData.specialAbility;
    }
    
    public virtual void InitState()
    {
        SetupCurrentHp();
        SetDefaultSpeed();
    }

    private void SetupCurrentHp()
    {
        CurrentHp = MaxHP;
    }

    private void SetDefaultSpeed()
    {
        CurrentSpeed = Speed;
    }

    public void ResetHpBar()
    {
        healthBar.Reset();
    }

    public void ResetCurrentSpeed()
    {
        CurrentSpeed = Speed;
    }
    #endregion

    #region UNIT ACTION STATE
    // public abstract void Move();

    public abstract void SetMovingDirection();

    public virtual void TakeDamage(float damage)
    {
        CurrentHp = Mathf.Max(CurrentHp - damage, 0);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.ResizeOnCurrentHp(MaxHP, CurrentHp);
    }

    //public abstract void Die();

    public void ApplyBulletEffect(List<IEffect> effects)
    {
        foreach(IEffect effect in effects)
        {
            EffectBase effectBase = effect as EffectBase;
            if(underEffect.ContainsKey(effectBase.type))
            {
                continue;
            }
            underEffect.Add(effectBase.type, effect);
            StartCoroutine(effect.ApplyEffect(this));
        }
    }
    #endregion

    #region GET ANIMATION
    public void GetAnimation()
    {
        unitAnatation = GetComponent<UnitAnimation>();
        unitAnatation.GetAnimation();
    }
    #endregion

    public virtual void ResetUnit()
    {
        SetupCurrentHp();
        ResetHpBar();
        SetDefaultSpeed();
        underEffect.Clear();
    }
}
