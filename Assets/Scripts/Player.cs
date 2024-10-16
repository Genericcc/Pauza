using System.Collections.Generic;
using System.Linq;

using Activities;

using LevelPOIs;

using MEC;

using StarterAssets;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public Inventory Inventory { get; private set; }
    
    [SerializeField]
    private LayerMask interactionLayers;
    
    [SerializeField]
    private float interactRange;
    
    // [SerializeField]
    // private int maxHits;
    
    [SerializeField]
    private float tripTime;
    
    private FirstPersonController _firstPersonController;
    private CameraShake _cameraShake;
    private Collider[] _colliders; 
    private bool _isOccupied;
    public int CurrentHp { get; private set; }

    private PlayerSpawnPoint _spawnPoint;

    [SerializeField]
    public ParticleSystem fixParticles;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } 
        
        Instance = this;        
    }

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");

        Inventory = GetComponent<Inventory>();
        _firstPersonController = GetComponent<FirstPersonController>();
        
        _colliders = new Collider[30];
        CurrentHp = 3;
        
        _spawnPoint = FindObjectOfType<PlayerSpawnPoint>();

        if (_spawnPoint != null)
        {
            transform.position = _spawnPoint.transform.position;
        }
        
        _firstPersonController.Disable(false);
    }

    private void Update()
    {
        HandleInventory();
        CheckForInteractables();

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     Time.timeScale = 0.2f;
        // }
    }
 
    private void HandleInventory()
    {
        if (Inventory == null || _isOccupied)
        {
            return;
        }
        
        if (Mouse.current.scroll.ReadValue().y > 0)
        {
            Inventory.SelectPrevious();
        }
        
        if (Mouse.current.scroll.ReadValue().y < 0)
        {
            Inventory.SelectNext();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Inventory.currentItem?.Use(this);
        }
    }

    private void CheckForInteractables()
    {
        var hits = Physics.OverlapSphereNonAlloc(transform.position, interactRange, _colliders, interactionLayers);

        if (hits <= 0)
        {
            return;
        }
        
        foreach (var interactableObject in _colliders.Where(x => x != null))
        {
            if (!interactableObject.TryGetComponent(out IInteractable interactable))
            {
                continue;
            }

            if (interactable.CanInteract(this))
            {
                Debug.Log("Press E to interact");

                if (!Input.GetKeyDown(KeyCode.E))
                {
                    continue;
                }

                Debug.Log("Interacted");

                interactable.Interact(this);
            }
            else
            {
                Debug.Log("Can't interact");
            }
        }
    }

    public void Freeze()
    {
        _isOccupied = true;
        _firstPersonController.Disable(true);
    }

    public void Free()
    {
        _isOccupied = false;
        _firstPersonController.Disable(false);
    }

    public void Damage()
    {
        CurrentHp--;

        CameraShake.Instance.ShakeCamera();
       
        TripPlayer();

        if (CurrentHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (transform.position.y < 10f)
        {
            transform.position = _spawnPoint.transform.position;
        }
    }

    private void TripPlayer()
    {
        Timing.RunCoroutine(_Trip().CancelWith(gameObject));
    }
    
    private IEnumerator<float> _Trip()
    {        
        _firstPersonController.Disable(true);
    
        var startRotation = transform.rotation;
        var endRotation = Quaternion.Euler(-90, 0, 0);
     
        var elapsedTime = 0f;
        while (elapsedTime < tripTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / tripTime);
            elapsedTime += Time.deltaTime;
            yield return Timing.WaitForOneFrame;
        }
    
        yield return Timing.WaitForSeconds(tripTime);
        
        elapsedTime = 0f;
        while (elapsedTime < tripTime)
        {
            transform.rotation = Quaternion.Slerp(endRotation, startRotation, elapsedTime / tripTime);
            elapsedTime += Time.deltaTime;
            yield return Timing.WaitForOneFrame;
        }
     
        transform.rotation = startRotation;
    
        _firstPersonController.Disable(false);
    }

    public void OnMenuOpened()
    {
        _firstPersonController.Disable(true);
    }

    public void OnMenuClosed()
    {
        _firstPersonController.Disable(false);
    }
}