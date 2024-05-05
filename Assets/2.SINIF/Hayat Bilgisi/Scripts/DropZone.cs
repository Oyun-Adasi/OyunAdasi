using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform dropZoneTransform;
    public GameObject droppedObject;
    public HBDrag HBDragScript;
    

    

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        HBDragScript = eventData.pointerDrag.GetComponent<HBDrag>();

        if(CheckDroppedObject(HBDragScript.gameObject.name, gameObject)){
            Debug.Log("OnDrop");
            HBDragScript.gameObject.SetActive(false);
        }

    }

    private void Awake()
    {
        HBDragScript=droppedObject.GetComponent<HBDrag>();
        Debug.Log("HBDragScript: " + HBDragScript);  
    }
    public bool CheckDroppedObject(string droppedObject, GameObject dropZone){
        //dropZone.GetComponent<Collider2D>();
        if(droppedObject==dropZone.name){
            return true;
        }
        return false;
    }
}