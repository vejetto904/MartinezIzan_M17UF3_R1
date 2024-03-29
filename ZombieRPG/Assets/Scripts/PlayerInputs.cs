using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Interact focus;
    Camera cam;
    public Transform hand;
    public Animator animator;
    public AudioSource song;
    public static PlayerInputs instance;

    private void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Obtener la c�mara principal de la escena
        cam = Camera.main;

        if (cam == null)
        {
            Debug.LogError("No se ha encontrado una c�mara principal en la escena.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            return; // Salir de la funci�n Update si la c�mara no est� inicializada
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interact interact = hit.collider.GetComponent<Interact>();
                if (interact != null)
                {
                    SetFocus(interact);
                }
            }
        }
        Dance();
    }
    public void Dance()
    {
        song.Pause();
        if (Inventory.instance.CountItems() == 3)
        {
            song.Play();
            animator.SetBool("isDance", true);
        }
    }

    void SetFocus(Interact newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null) 
                focus.DeFocused();

            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }


    //M�todo para equipar un objeto en la mano del jugador
    public void EquipItemInHand(Item newItem)
    {
        // Destruir el arma actualmente equipada en la mano, si existe
        if (hand.childCount > 0)
        {
            Destroy(hand.GetChild(0).gameObject);
        }

        // Establecer la animaci�n de ataque
        animator.SetLayerWeight(animator.GetLayerIndex("Atack"), 1);

        // Instanciar y equipar la nueva arma en la mano del jugador
        GameObject newItemObject = Instantiate(newItem.prefab, hand.position, hand.rotation);
        newItemObject.transform.parent = hand;

        // Ajustar el tama�o del objeto
        newItemObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // Ajustar la rotaci�n y posici�n del objeto en la mano
        newItemObject.transform.localRotation = Quaternion.Euler(new Vector3(3.95f, 6.7f, 86.63f));
        newItemObject.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.05f);
    }
}
