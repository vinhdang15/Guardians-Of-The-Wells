using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TowerPresenter : MonoBehaviour
{
    public TowerModel        towerModel;
    public TowerViewBase     towerViewBase;
    public EmptyPlot         emptyPlot;
    public int               CurentTowerDamage { set ; get ; }
    public string            DescriptionUpgrade { set ; get ; }
    public int               TowerDamageUpgrade { set ; get ; }
    public float             TowerSpawnRateUpgrade { set ; get ; }
    public float             RangeDetectUpgrade { set ; get ; }
    public int               GoldUpgrade { set ; get ; }
    public int               GoldRefund { set ; get ; }

    public static TowerPresenter Create(TowerModel towerModel, TowerViewBase towerView)
    {
        TowerPresenter towerPresenter = towerView.gameObject.AddComponent<TowerPresenter>();
        towerPresenter.TowerPresenterInit(towerModel, towerView);
        return towerPresenter;
    } 
    
    public void TowerPresenterInit(TowerModel towerModel, TowerViewBase towerView)
    {
        this.towerModel = towerModel;
        this.towerViewBase  = towerView;
        InitTowerRange();
        AddGoldInitRefund();
        SetTowerPresenterData();
    }

    public void InitTowerRange()
    {
        towerViewBase.SetRangeRaycat(towerModel.RangeRaycast);
        towerViewBase.SetRangeDetect(towerModel.RangeDetect);
    }

    public void SetTowerPresenterData()
    {
        string towerType    = towerModel.TowerType;
        int towerLevel      = towerModel.Level;

        DescriptionUpgrade      = CSVTowerDataReader.Instance.towerDataList.GetDescription(towerType, towerLevel + 1);
        GoldUpgrade             = CSVTowerDataReader.Instance.towerDataList.GetGoldRequired(towerType, towerLevel + 1);
        RangeDetectUpgrade      = CSVTowerDataReader.Instance.towerDataList.GetRangeDetect(towerType, towerLevel + 1);
        TowerSpawnRateUpgrade   = CSVTowerDataReader.Instance.towerDataList.GetSpawnRate(towerType, towerLevel + 1);

        switch(towerType)
        {
            case string t when  t == TowerType.ArcherTower.ToString().Trim().ToLower() ||
                                t == TowerType.MageTower.ToString().Trim().ToLower() ||
                                t == TowerType.CannonTower.ToString().Trim().ToLower():
                string bullet = CSVTowerDataReader.Instance.towerDataList.GetTowerSpawnObject(towerType, towerLevel);
                CurentTowerDamage = CSVBulletDataReader.Instance.bulletDataList.GetBulletDamage(bullet);
                if(towerLevel + 1 > 2) return;
                string bulletUpgrade = CSVTowerDataReader.Instance.towerDataList.GetTowerSpawnObject(towerType, towerLevel + 1);
                TowerDamageUpgrade = CSVBulletDataReader.Instance.bulletDataList.GetBulletDamage(bulletUpgrade);
                break;

            case string t when t == TowerType.Barrack.ToString().Trim().ToLower():
                string soldier = CSVTowerDataReader.Instance.towerDataList.GetTowerSpawnObject(towerType, towerLevel);
                CurentTowerDamage = CSVUnitDataReader.Instance.unitDataList.GetUnitDamage(soldier);
                if(towerLevel + 1 > 2) return;
                string soldierUpgrade = CSVTowerDataReader.Instance.towerDataList.GetTowerSpawnObject(towerType, towerLevel + 1);
                TowerDamageUpgrade = CSVUnitDataReader.Instance.unitDataList.GetUnitDamage(soldierUpgrade);
                break;
        }
    }

    public void AddGoldRefund(int gold)
    {
        GoldRefund += gold;
    }

    private void AddGoldInitRefund()
    {
        GoldRefund += towerModel.GoldRequired;
    }
}
