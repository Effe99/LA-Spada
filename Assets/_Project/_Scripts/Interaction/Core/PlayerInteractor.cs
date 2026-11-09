using UnityEngine;
using UnityEngine.InputSystem;

// ricordare che questo script deve collaborare con CrosshairUI e ObjectHolder e quindi va aggiornato alla creazione di quegli script
public class PlayerInteractor : MonoBehaviour    // si occupa di rilevare e gestire l'interazione               
{
    [SerializeField] private float interactionDistance = 3f; // distanza massima di interazione

    private Camera playerCamera;
    private PlayerControls controls; //gestisco gli input actions
    private Interactable currentInteractable; // va a memorizzare l'oggetto oservato

    private void Awake()
    {
        controls = new PlayerControls();   // creo una nuova istanza e richiamo le input action per poter accedere
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void OnEnable() // quando il giocatore clicca "E" esegui il metodo interact
    {
        controls.Player.Enable();  // ricevo gli input action configurati
        controls.Player.Interact.performed += OnInteract;  // "controls.player" accede alle action map player, "interact" accede all'azione interact e "performed" rappresenza l'evento generato quando l'azione viene eseguita
    }

    private void OnDisable() // evita che il sistema continui ad ascoltare gli input quando il componente non è attivo
    {
        controls.Player.Interact.performed -= OnInteract;
        controls.Player.Disable();
    }

    private void Update() // controlliamo continuamente cosa guarda il player
    {
        if (playerCamera == null)
            return;  // evitiamo che il raycast viene attivato senza una telecamera valida

        currentInteractable = null; // evitiamo che l'oggetto memorizzato dal codice rimanga quello visualizzato prima e quindi va azzerato per evitare errori

        Ray ray = playerCamera.ViewportPointToRay         // creo il raggio dal centro dello schermo
        ( 
            new Vector3(0.5f, 0.5f, 0f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))   // verifico se il raggio colpisce un oggetto (E QUNDI UN COLLIDER) entro la distanza massima di interazione // "out RaycastHit hit" restituisce le informazioni sull'oggetto colpito
        {
            currentInteractable = hit.collider.GetComponentInParent<Interactable>();
        }
    }

    private void OnInteract(InputAction.CallbackContext context)  // gestisce la pressione del tasto E per l'interazione
    {
        if (currentInteractable != null)
            currentInteractable.Interact();
    }
}
