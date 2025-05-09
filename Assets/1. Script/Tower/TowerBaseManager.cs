using System.Collections.Generic;
using UnityEngine;

public class TowerBaseManager : MonoBehaviour
{
    #region INIT BUILDING
    protected TowerPresenter InitBuildingPresenter(TowerViewBase towerPrefab, TowerData towerData, Vector3 pos)
    {
        TowerViewBase buildingView          = Instantiate(towerPrefab, pos, Quaternion.identity, transform);
        TowerModel buildingModel            = TowerModel.Craete(buildingView,towerData);
        TowerPresenter towerPresenter       = TowerPresenter.Create(buildingModel, buildingView);
        return towerPresenter;
    }

    protected void AddTowerPersenterEmptyPlot(TowerPresenter towerPresenter, EmptyPlot emptyPlot)
    {
        towerPresenter.emptyPlot = emptyPlot;
        // towerPresenter.emptyPlot.HideEmptyPlot();
    }

    #endregion

    #region UPGRADE BUILDING
    public void UpgradeTower(TowerPresenter towerPresenter)
    {
        // upgrade tower mode
        string towerType = towerPresenter.towerModel.TowerType;
        int towerLevel = towerPresenter.towerModel.Level;
        TowerData towerData = TowerDataReader.Instance.towerDataListSO.GetTowerData(towerType, towerLevel + 1);
        towerPresenter.towerModel.UpgradeTowerModel(towerData);
        
        // upgrade range, range upgrade
        UpdateRangeDetection(towerPresenter);
        UpdateRangeDetectionUpgrade(towerPresenter);

        // Upgrade TowerPresenter data after upgrade tower
        towerPresenter.SetTowerPresenterData();
    }

    private void UpdateRangeDetection(TowerPresenter buildingPresenter)
    {
        float rangeDetect = buildingPresenter.towerModel.RangeDetect;
        buildingPresenter.towerViewBase.SetRangeDetect(rangeDetect);
    }

    public void UpdateRangeDetectionUpgrade(TowerPresenter buildingPresenter)
    {
        float rangeDetectUpgrade = buildingPresenter.RangeDetectUpgrade;
        buildingPresenter.towerViewBase.SetRangeDetectUpgrade(rangeDetectUpgrade);
    }
    #endregion
}