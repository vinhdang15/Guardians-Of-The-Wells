using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;
    [SerializeField] RaycastHandler raycastHandler;
    [SerializeField] TowerActionHandler towerActionHandler;
    [SerializeField] GamePlayManager gamePlayManager;

    [Header("GameMenu")]
    [SerializeField] PanelUI pauseMenu;
    [SerializeField] PanelUI victoryMenu;
    [SerializeField] PanelUI gameOverMenu;

    [Header("TowerMenu")]
    [SerializeField] InitMenu initMenu;
    [SerializeField] UpgradeMenu upgradeMenu;
    [SerializeField] CheckSymbol checkSymbol;

    [Header("TowerStatus")]
    [SerializeField] CurrentSttPanel currentSttPanel;
    [SerializeField] UpgradeSttPanel upgradeSttPanel;

    [Header("GameStatus")]
    [SerializeField] GameSttPanel gameSttPanel;

    
    private Vector2        initMenuPanelPos;
    private TowerPresenter selectedTower;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadComponents();
    }

    // private void Start()
    // {
    //     GetTotalWave();
    //     ResetCurrentWave();
    //     UpdateCurrentGold();
    //     RegisterInputControllerEvent();
    //     RegisterGamePlayManagerEvent();
    // }

    public void PanelManagerPrepareGame()
    {
        GetTotalWave();
        ResetCurrentWave();
        UpdateCurrentGold();
        RegisterInputControllerEvent();
        RegisterGamePlayManagerEvent();
    }

    private void OnDisable()
    {
        UnregisterInputControllerEvent();
        UnregisterGamePlayManagerEvent();
    }

    private void LoadComponents()
    {
        raycastHandler      = FindObjectOfType<RaycastHandler>();
        towerActionHandler  = FindObjectOfType<TowerActionHandler>();
        gamePlayManager     = FindObjectOfType<GamePlayManager>();

        initMenu            = FindObjectOfType<InitMenu>();
        // initMenu.Hide();
        upgradeMenu         = FindObjectOfType<UpgradeMenu>();
        checkSymbol         = FindObjectOfType<CheckSymbol>();

        pauseMenu           = FindObjectOfType<PanelUI>();
        victoryMenu         = FindObjectOfType<PanelUI>();
        gameOverMenu        = FindObjectOfType<PanelUI>();

        currentSttPanel     = FindObjectOfType<CurrentSttPanel>();
        currentSttPanel.Hide();
        upgradeSttPanel     = FindObjectOfType<UpgradeSttPanel>();
        gameSttPanel        = FindObjectOfType<GameSttPanel>();
    }

    #region REGISTER EVENT
    private void RegisterInputControllerEvent()
    {
        raycastHandler.OnRaycastHitNull                += HandleRaycastHitNull;
        raycastHandler.OnSelectedEmptyPlot             += HandleOnSelectedEmptyPlot;
        raycastHandler.OnSelectedEmptyPlot             += HandleOnSelectedEmptyPlot;
        raycastHandler.OnSelectedBulletTower           += HandleOnSelectedBulletTower;
        raycastHandler.OnSelectedBarrackTower          += HandleOnSelectedBarrackTower;

        towerActionHandler.OnFirstButtonClick          += HandleShowCheckSymbol;
        towerActionHandler.OnTryToInitTower            += HandleOnTryToInitTower;
        towerActionHandler.OnGuardPointBtnClick        += HandleGuardPointBtnClick;
        towerActionHandler.OnTryToUpgradeTower         += HandleOnTryToUpgradeTower;
    }

    private void UnregisterInputControllerEvent()
    {
        raycastHandler.OnRaycastHitNull                -= HandleRaycastHitNull;
        raycastHandler.OnSelectedEmptyPlot             -= HandleOnSelectedEmptyPlot;
        raycastHandler.OnSelectedEmptyPlot             -= HandleOnSelectedEmptyPlot;
        raycastHandler.OnSelectedBulletTower           -= HandleOnSelectedBulletTower;
        raycastHandler.OnSelectedBarrackTower          -= HandleOnSelectedBarrackTower;

        towerActionHandler.OnFirstButtonClick          -= HandleShowCheckSymbol;
        towerActionHandler.OnTryToInitTower            -= HandleOnTryToInitTower;
        towerActionHandler.OnGuardPointBtnClick        -= HandleGuardPointBtnClick;
        towerActionHandler.OnTryToUpgradeTower         -= HandleOnTryToUpgradeTower;
    }

    private void RegisterGamePlayManagerEvent()
    {
        gamePlayManager.OnGoldChangeForUI                       += HandleGoldChange;
        gamePlayManager.OnLiveChangeForUI                       += HandleLiveChange;
        gamePlayManager.spawnEnemyManager.OnUpdateCurrentWave   += HandleUpdateCurrentWave;
    }

    private void UnregisterGamePlayManagerEvent()
    {
        gamePlayManager.OnGoldChangeForUI                       -= HandleGoldChange;
        gamePlayManager.OnLiveChangeForUI                       -= HandleLiveChange;
        gamePlayManager.spawnEnemyManager.OnUpdateCurrentWave   -= HandleUpdateCurrentWave;
    }
    #endregion

    #region PANEL, MENU VISIBLE
    private void HandleOnTryToInitTower(TowerType type, EmptyPlot plot)
    {
        upgradeSttPanel.SetInitSttText(type);
        upgradeSttPanel.ShowInPos(plot.transform.position);
    }

    private void HandleOnTryToUpgradeTower(TowerPresenter towerPresenter)
    {
        upgradeSttPanel.SetUpgradeSttText(towerPresenter);
        upgradeSttPanel.ShowInPos(towerPresenter.transform.position);
    }

    private void HandleShowCheckSymbol(Button clickedButton)
    {
        checkSymbol.transform.position = clickedButton.transform.transform.position;
        checkSymbol.GreyOutCheckSymbol(clickedButton);
        checkSymbol.Show();
    }

    public void HandleRaycastHitNull()
    {
        initMenu.Hide();
        upgradeMenu.Hide();
        checkSymbol.Hide();
        upgradeSttPanel.Hide();
        currentSttPanel.Hide();
        currentSttPanel.Hide();
        upgradeSttPanel.Hide();
    }

    private void HandleOnSelectedEmptyPlot(EmptyPlot emptyPlotPos)
    {   
        initMenuPanelPos = emptyPlotPos.transform.position;
        initMenu.Hide();
        upgradeMenu.Hide();
        checkSymbol.Hide();
        upgradeSttPanel.Hide();
        currentSttPanel.Hide();
        initMenu.ButtonCheckInitGoldRequire(GetCurrentGold());
        initMenu.ShowInPos(emptyPlotPos.transform.position);
    }

    private void HandleOnSelectedBulletTower(TowerPresenter selectedTowerPresenter)
    {
        selectedTower = selectedTowerPresenter;
        initMenu.Hide();
        checkSymbol.Hide();
        upgradeSttPanel.Hide();
        currentSttPanel.Hide();

        currentSttPanel.SetCurrentSttText(selectedTowerPresenter);
        currentSttPanel.Show();
        upgradeMenu.HideGuardPointBtn();
        upgradeMenu.UpdateText(selectedTowerPresenter);
        upgradeMenu.UpdateButtonColor(selectedTowerPresenter,GetCurrentGold());
        upgradeMenu.ShowInPos(selectedTowerPresenter.transform.position);
    }

    private void HandleOnSelectedBarrackTower(TowerPresenter presenter)
    {
        selectedTower = presenter;
        initMenu.Hide();
        checkSymbol.Hide();
        upgradeSttPanel.Hide();
        currentSttPanel.Hide();

        currentSttPanel.SetCurrentSttText(presenter);
        currentSttPanel.Show();
        upgradeMenu.ShowGuardPointBtn();
        upgradeMenu.UpdateText(presenter);
        upgradeMenu.UpdateButtonColor(presenter,GetCurrentGold());
        upgradeMenu.ShowInPos(presenter.transform.position);
    }

    private void HandleGuardPointBtnClick()
    {
        checkSymbol.Hide();
        upgradeSttPanel.Hide();
        currentSttPanel.Hide();
        upgradeMenu.Hide();
    }
    #endregion

    #region GAME STT PANEL
    private void ResetCurrentWave()
    {
        gameSttPanel.ResetCurrentWave();
    }
    
    private void GetTotalWave()
    {
        int totalWave = gamePlayManager.spawnEnemyManager.TotalWave;
        gameSttPanel.GetTotalWave(totalWave);
    }

    private void UpdateCurrentGold()
    {
        gameSttPanel.UpdateGold(GetCurrentGold());
    }
    private void HandleGoldChange()
    {
        UpdateCurrentGold();
        initMenu.ButtonCheckInitGoldRequire(GetCurrentGold());

        if(selectedTower == null) return;
        upgradeMenu.UpdateButtonColor(selectedTower,GetCurrentGold());
    }
    
    private void HandleUpdateCurrentWave(int currentWave)
    {
        gameSttPanel.HandleUpdateCurrentWave(currentWave);
    }

    private void HandleLiveChange()
    {
        int live = gamePlayManager.live;
        gameSttPanel.UpdateLive(live);
        if(live != 0) return;
        gameOverMenu.Show();
    }

    private int GetCurrentGold()
    {
        return gamePlayManager.gold;
    }
    #endregion

    #region GAME MENU
    public void ShowPauseMenu()
    {
        pauseMenu.Show();
    }

    public void HidePauseMenu()
    {
        pauseMenu.Hide();
    }

    public void ShowVictoryMenu()
    {
        victoryMenu.Show();
    }
    #endregion
}
