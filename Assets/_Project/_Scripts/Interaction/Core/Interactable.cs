using UnityEngine;

public abstract class Interactable : MonoBehaviour  // l'ho fatta abstract per evitare problemi nei collegamenti a un gameobject come componente concreto (se non serve possiamo toglierla)
{
    public abstract void Interact(); // creo il metodo interact che va a rappresentare l'azione da eseguire quando il player interagisce con un oggetto, non vado a scrivere cosa fa perche' ogni oggetto ha un comportamento diff
}                                    // pickable implementa il metodo per la raccolta, container la gestione del contenitore e trashbin la gestione del cestino
