using System.Linq;

using Activities;

using Items;

using StarterAssets;

using TMPro;

using UnityEditor;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private float interactRange = 2f;
    
    [SerializeField]
    private Transform currentItemTransform;
    
    public Inventory Inventory { get; private set; }
    
    private FirstPersonController _firstPersonController;
    private Collider[] _colliders; 
    
    [SerializeField]
    private LayerMask interactionLayers;

    private void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception("Player already exists");
        } 
        
        Instance = this;        
        
        _colliders = new Collider[30];

        Inventory = GetComponent<Inventory>();
        _firstPersonController = GetComponent<FirstPersonController>();
        
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        RefreshInventory();
        CheckForInteractables();
    }
 
    private void RefreshInventory()
    {
        if (Inventory == null)
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
        _firstPersonController.SetDisabled(true);
    }

    public void Free()
    {
        _firstPersonController.SetDisabled(false);
    }
}