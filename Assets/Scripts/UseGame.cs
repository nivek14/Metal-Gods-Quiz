using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGame : MonoBehaviour{

    [SerializeField] GameToUseData gameToUseData;

    public void SetGameToUse(int useThis){
        gameToUseData.gameToUse = useThis;
    }

}
