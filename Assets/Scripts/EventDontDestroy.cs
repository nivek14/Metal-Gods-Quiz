using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDontDestroy : MonoBehaviour{

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

}
