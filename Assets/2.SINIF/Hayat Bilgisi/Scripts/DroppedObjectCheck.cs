using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjectCheck : MonoBehaviour
{
    
    public bool CheckDroppedObject(string droppedObject, GameObject dropZone){
        dropZone.GetComponent<Collider2D>();
        if(droppedObject==dropZone.name){
            return true;
        }
        return false;
    }
}
