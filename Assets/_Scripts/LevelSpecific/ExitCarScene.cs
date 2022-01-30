using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCarScene : MonoBehaviour
{
    private CarShopManager carManager;

    private void Start() 
    {
        carManager = GameObject.Find("CarShopManager").GetComponent<CarShopManager>();
        Exit();
    }

    public void Exit() 
    {
        carManager.ExitCarShop();
    }
}
