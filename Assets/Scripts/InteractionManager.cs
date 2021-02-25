using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private bool debugRay;
    [SerializeField] private float interactionDistance;
    [SerializeField] private Image target;
    [SerializeField] private Image targetr;
    [SerializeField] private Image targetb;
    public static bool active = true;

    private Interactable pointingInteractable;
    private CharacterController DanteController;
    private Vector3 rayOrigin;
    public static float distance;
    private bool type;


    void Start()
    {
        targetr.enabled = false;
        targetb.enabled = true;
        DanteController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (active)
        {
            rayOrigin = cameraTransform.position + DanteController.radius * cameraTransform.forward;
            CheckInteraction();
            UpdateUITarget();

            if (debugRay)
                DebugRaycast();
        }


        if (!active)
        {

            //target.color = Color.white;
        }

    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(rayOrigin, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            //Store distance
            distance = hit.distance;


            //Check if is interactable
            pointingInteractable = hit.transform.GetComponent<Interactable>();


            if (pointingInteractable != null)
            {
                if (Input.GetMouseButtonDown(0))
                    pointingInteractable.Interact(gameObject);
            }


        }
        //If NOTHING is detected set all to null
        else
        {
            pointingInteractable = null;
        }
    }

    private void UpdateUITarget()
    {
        if (pointingInteractable != null)
        {

            if (pointingInteractable.ObtainType() == true)
            {
                target.enabled = false;
                targetr.enabled = true;
                //GameObject.Find("PiumaW").SetActive(false);
                //target.color = Color.red;
            }
            else
            {
                target.enabled = false;
                targetb.enabled = true;
                //target.color = Color.cyan;
            }
        }


        else
        {
            target.enabled = true;
            targetr.enabled = false;
            targetb.enabled = false;
            //target.color = Color.white;
        }

    }


    private void DebugRaycast()
    {
        Debug.DrawRay(rayOrigin, cameraTransform.forward * interactionDistance, Color.white);
    }


}
