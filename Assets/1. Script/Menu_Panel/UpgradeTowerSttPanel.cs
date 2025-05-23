using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UpgradeTowerSttPanel : UIElementBase
{
    [SerializeField] TextMeshProUGUI    descriptionText;
    [SerializeField] TextMeshProUGUI    towerDamageText;
    [SerializeField] TextMeshProUGUI    spawnRateText;
    private TowerDataReader             towerDataReader;
    private BulletDataReader            bulletDataReader;
    private UnitDataReader              unitDataReader;

    public void PrepareGame(TowerDataReader towerDataReader, BulletDataReader bulletDataReader,
                            UnitDataReader unitDataReader)
    {
        this.towerDataReader    = towerDataReader;
        this.bulletDataReader   = bulletDataReader;
        this.unitDataReader     = unitDataReader;
    }

    public void SetUpgradeSttText(TowerPresenter towerPresenter)
    {
        if (towerPresenter.towerModel.Level == 2) return;
        //int currentLevel = tower.currentLevel;
        descriptionText.text = towerPresenter.DescriptionUpgrade.Replace("\\n", Environment.NewLine); ;
        towerDamageText.text = "Damage: " + towerPresenter.TowerDamageUpgrade.ToString();
        spawnRateText.text   = "Fire Rate: " + towerPresenter.TowerSpawnRateUpgrade.ToString() + "s";
    }

    public void SetInitSttText(TowerType towerType)
    {
        string type = towerType.ToString();
        TowerData towerData = towerDataReader.towerDataListSO.GetTowerData(type, 1);

        //int currentLevel = tower.currentLevel;
        descriptionText.text = towerData.descriptions.Replace("\\n", Environment.NewLine);
        spawnRateText.text = "Fire Rate: " + towerData.spawnRate.ToString() + "s";

        switch(type)
        {
            case string t when  t == TowerType.ArcherTower.ToString() ||
                                t == TowerType.MageTower.ToString() ||
                                t == TowerType.CannonTower.ToString():
                string bullet = towerDataReader.towerDataListSO.GetTowerSpawnObject(type, 1);
                towerDamageText.text = "Damage: " +  bulletDataReader.bulletDataListSO.GetBulletDamage(bullet).ToString();
                break;

            case string t when t == TowerType.Barrack.ToString():
                string soldier = towerDataReader.towerDataListSO.GetTowerSpawnObject(type, 1).ToString();
                towerDamageText.text = "Soldier Damage: " +  unitDataReader.unitDataListSO.GetUnitDamage(soldier).ToString();
                break;
        }
    }

    public override void ShowInPos(Vector2 pos)
    {
        float offsetInXAxis = 6f;
        if(pos.x >= 0)
        {
            offsetInXAxis = Mathf.Abs(offsetInXAxis) * -1;
        }
        else
        {
            offsetInXAxis = Mathf.Abs(offsetInXAxis);
        }
        float x = pos.x + offsetInXAxis;
        float y = pos.y;
        transform.position = new Vector2(x, y);
        gameObject.SetActive(true);
        transform.DOScale(1, timeDelay);
    }
}
