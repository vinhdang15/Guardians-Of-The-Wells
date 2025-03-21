using System.Collections;
using UnityEngine;

public class GameInitiator_Save : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private CameraController cameraController;

    [Header("Load Data")]
    [SerializeField] private CSVEmptyPlotDataReader     _CSVEmptyPlotDataReader;
    [SerializeField] private CSVTowerDataReader         _CSVTowerDataReader;
    [SerializeField] private CSVBulletDataReader        _CSVBulletDataReader;
    [SerializeField] private CSVBulletEffectDataReader  _CSVBulletEffectDataReader;
    [SerializeField] private CSVUnitDataReader          _CSVUnitDataReader;
    [SerializeField] private CSVSkillDataReader         _CSVSkillDataReader;

    [Header("Effects")]
    [SerializeField] private VisualEffectPool visualEffectPool;

    [Header("Init Canvas")]
    [SerializeField] private GameObject canvasScreenSpace;
    [SerializeField] private GameObject canvasWorldSpace;

    [Header("LevelManager")]
    [SerializeField] private LevelManager levelManager;

    [Header("GameManager")]        
    [SerializeField] private FPSCounter fPSCounter; //
    
    [SerializeField] private EmptyPlotManager emptyPlotManager; //
    [SerializeField] private BulletTowerManager bulletTowerManager; //
    [SerializeField] private BarrackTowerManager barrackTowerManager; //
    [SerializeField] private SoldierManager soldierManager; //
    [SerializeField] private BulletManager bulletManager; //
    [SerializeField] private EnemyManager enemyManager; //

    [SerializeField] private RaycastHandler raycastHandler; //
    [SerializeField] private InputButtonHandler inputButtonHandler; //
    [SerializeField] private TowerActionHandler towerActionHandler; //

    [SerializeField] private PanelManager panelManager; //
    [SerializeField] private GamePlayManager gamePlayManager;//
    [SerializeField] private CautionManager cautionManager; //
    private VictoryMenu victoryMenu;
    private GameObject gameManager;
    private GameObject poolManager;
    private GameObject levelData;
    
    private void Awake()
    {
        gameManager = new GameObject("GameManager");
        poolManager = new GameObject("PoolManager");
        levelData = new GameObject("LevelManager");
    }
    private IEnumerator Start()
    {
        yield return StartCoroutine(LoadData());
        yield return StartCoroutine(BindCanvas());
        yield return StartCoroutine(BindObjects());
        yield return StartCoroutine(BindPoolObject());
        yield return StartCoroutine(PrepareGame());
    }
    
    private IEnumerator LoadData()
    {
        Instantiate(_CSVEmptyPlotDataReader);
        Instantiate(_CSVTowerDataReader);
        Instantiate(_CSVBulletDataReader);
        Instantiate(_CSVBulletEffectDataReader);
        Instantiate(_CSVUnitDataReader);
        Instantiate(_CSVSkillDataReader);
        yield return null;
    }

    private IEnumerator BindCanvas()
    {
        canvasScreenSpace = Instantiate(canvasScreenSpace);
        canvasScreenSpace.name = InitNameObject.CanvasScreenSpace.ToString();
        canvasWorldSpace = Instantiate(canvasWorldSpace);
        canvasWorldSpace.name = InitNameObject.CanvasWorldSpace.ToString();
        yield return null;
    }

    private IEnumerator BindObjects()
    {
        cameraController = Instantiate(cameraController);
        cameraController.name = InitNameObject.Camera.ToString();

        levelManager.BindMap(levelData);

        fPSCounter = Instantiate(fPSCounter, gameManager.transform);
        fPSCounter.name = InitNameObject.FPSCounter.ToString();

        levelManager.BindPoolObject(levelData);

        emptyPlotManager = Instantiate(emptyPlotManager, gameManager.transform);
        emptyPlotManager.name = InitNameObject.EmptyPlotManager.ToString();

        bulletManager = Instantiate(bulletManager, gameManager.transform);
        bulletManager.name = InitNameObject.BulletManager.ToString();

        soldierManager = Instantiate(soldierManager, gameManager.transform);
        soldierManager.name = InitNameObject.SoldierManager.ToString();

        bulletTowerManager = Instantiate(bulletTowerManager, gameManager.transform);
        bulletTowerManager.name = InitNameObject.BulletTowerManager.ToString();

        barrackTowerManager = Instantiate(barrackTowerManager, gameManager.transform);
        barrackTowerManager.name = InitNameObject.BarrackTowerManager.ToString();

        enemyManager = Instantiate(enemyManager, gameManager.transform);
        enemyManager.name = InitNameObject.EnemyManager.ToString();

        cautionManager = Instantiate(cautionManager, gameManager.transform);
        cautionManager.name = InitNameObject.CautionManager.ToString();

        levelManager.BindSpawnEnemyManager(levelData);
        levelManager.BindSpawnEnemiesObject(levelData);

        raycastHandler = Instantiate(raycastHandler, gameManager.transform);
        raycastHandler.name = InitNameObject.RaycastHandler.ToString();
        
        inputButtonHandler = Instantiate(inputButtonHandler, gameManager.transform);
        inputButtonHandler.name = InitNameObject.InputButtonHandler.ToString();

        towerActionHandler = Instantiate(towerActionHandler, gameManager.transform);
        towerActionHandler.name = InitNameObject.TowerActionHandler.ToString();

        gamePlayManager = Instantiate(gamePlayManager, gameManager.transform);
        gamePlayManager.name = InitNameObject.GamePlayManager.ToString();

        panelManager = Instantiate(panelManager, gameManager.transform);
        panelManager.name = InitNameObject.PanelManager.ToString();
        yield return null;
    }

    private IEnumerator BindPoolObject()
    {
        Instantiate(visualEffectPool);
        yield return null;
    }

    private IEnumerator PrepareGame()
    {
        levelManager.SpawnEnemyManagerPrepareGame();
        cautionManager.CautionManagerPrepareGame();
        levelManager.SpawnEnemiesPrepareGame();
        raycastHandler.RaycastHandlerPrepareGame();
        inputButtonHandler.InputButtonHandlerPrepareGame();
        towerActionHandler.PrepareGame();
        gamePlayManager.PrepareGame();
        panelManager.PrepareGame();
        cameraController.LoadComponents(levelManager.GetMapPolygonCollider2D());
        yield return null;
    }

}
