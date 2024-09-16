using System.Linq;

using Activities;

using Items;

using StarterAssets;

using TMPro;

using UnityEditor;

using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private float interactRange = 2f;
    
    [SerializeField]
    private LayerMask interactionLayers;

    [SerializeField]
    public TextMeshProUGUI interactText;
    
    [SerializeField]
    public TextMeshProUGUI cantInteractText;

    private Collider[] _colliders;

    public Inventory Inventory { get; set; }
    public FirstPersonController FirstPersonController { get; set; }

    private void Awake()
    {
        Instance = this;        
        
        _colliders = new Collider[30];

        Inventory = GetComponent<Inventory>();
        FirstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        var hits = Physics.OverlapSphereNonAlloc(transform.position, interactRange, _colliders, interactionLayers);

        if (hits <= 0)
        {
            return;
        }
        
        foreach (var interactableObject in _colliders.Where(x => x != null))
        {
            if (interactableObject.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.CanInteract(this))
                {
                    Debug.Log("Press E to interact");
                
                    if (Input.GetKeyDown(KeyCode.E))
                    {                
                        Debug.Log("Interacted");

                        interactable.Interact(this);
                    }
                }
                else
                {
                    Debug.Log("Can't interact");
                }
            }
        }
    }

    public void Freeze()
    {
        FirstPersonController.SetDisabled(true);
    }

    public void Free()
    {
        FirstPersonController.SetDisabled(false);
    }
}