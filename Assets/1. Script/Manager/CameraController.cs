using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject virtualCamera;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineConfiner cinemachineConfiner;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomSpeed = 0.1f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 5.4f;
    [SerializeField] private float panSpeed = 0.5f;
    [SerializeField] private float panThreshold = 0.5f;
    private Vector3 touchStart;
    private Vector3 moveStart = new Vector3(0,0,-10);
    private bool isLoadComponents = false;


    private void Awake()
    {
        LoadComponents();
    }    
    private void LoadComponents()
    {
        cinemachineVirtualCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        cinemachineConfiner = virtualCamera.GetComponent<CinemachineConfiner>();
    }

    private void Update()
    {
        if(!isLoadComponents) return;
        if(Input.touchCount == 1)
        {
            HandleTouchPan();
        }
        else if(Input.touchCount == 2)
        {
            HandleTouchZoom();
        }

        if(Input.GetMouseButtonDown(0))
        {
            // Di chuyển bản đồ bằng chuột
            touchStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if(direction.magnitude <= panThreshold)
            {
                moveStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                Vector3 moveDirection = moveStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
                cinemachineVirtualCamera.transform.position += moveDirection * panSpeed;
            }
        }

        // Phóng to và thu nhỏ bằng con lăn chuột
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scrollData * zoomSpeed);
    }

    private void Zoom(float increment)
    {
        cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(mainCamera.orthographicSize - increment, minZoom, maxZoom);
    }

    private void HandleTouchInput()
    {
        if(Input.touchCount == 1)
        {
            HandleTouchPan();
        }
        else if(Input.touchCount == 2)
        {
            // Phóng to và thu nhỏ bằng hai ngón tay
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
        }
    }

    private void HandleTouchPan()
    {
        // Di chuyển bản đồ bằng một ngón tay
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            touchStart = mainCamera.ScreenToWorldPoint(touch.position);
        }
        else if(touch.phase == TouchPhase.Moved)
        {
            Vector3 direction = touchStart - mainCamera.ScreenToWorldPoint(touch.position);
            if(direction.magnitude <= panThreshold)
            {
                moveStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                Vector3 moveDirection = moveStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
                cinemachineVirtualCamera.transform.position += moveDirection * panSpeed;
            }
        }
    }

    private void HandleTouchZoom()
    {
        // Phóng to và thu nhỏ bằng hai ngón tay
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        float difference = currentMagnitude - prevMagnitude;

        Zoom(difference * zoomSpeed);
    }

    public void LoadComponents(PolygonCollider2D polygonCollider2D)
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
        isLoadComponents = true;
    }
}