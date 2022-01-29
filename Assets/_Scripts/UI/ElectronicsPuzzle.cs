using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronicsPuzzle : MonoBehaviour
{
	private RadioStationManager radioManager;
    
    public Sprite[] ABC_State;  //0-1=A,2-3=B,4-5=C
    public Image A_indicator, B_indicator, C_indicator;
	
	public GameObject A_button, B_button, C_button;
	public GameObject[] Wires; //0A,1B,2C-ON,3C-OFF,4AB,5-OUTPUT
	public GameObject output;

	private bool A, B, C, AB;

	private void Start()
	{
		radioManager = GameObject.Find("RadioStationManager").GetComponent<RadioStationManager>();

		//off state sprite
		A_indicator.sprite = ABC_State[0];
		B_indicator.sprite = ABC_State[2];
		C_indicator.sprite = ABC_State[5];

		A = false; B = false; C = false; AB = false;

		foreach(GameObject wire in Wires)
		{
			wire.SetActive(false); 
		}

		//C
		Wires[2].SetActive(true);
	}
	private void WinCondition()
	{
		foreach (GameObject wire in Wires)
		{
			wire.SetActive(false);
		}
		Wires[5].SetActive(true);

		//remove clicking btn permission
		A_button.GetComponent<Button>().interactable = false;
		B_button.GetComponent<Button>().interactable = false;
		C_button.GetComponent<Button>().interactable = false;

		//turns output light green; notifies GM
		output.SetActive(false);
		radioManager.ElectronicsPuzzleComplete();
		
	}
	public void ButtonPress(int index)
	{
		switch(index)
		{
			case 1:
				A = !A;
				A_indicator.sprite = A ? ABC_State[1] : ABC_State[0];
				WireSelect(0);
				break;
			case 2:
				B = !B;
				B_indicator.sprite = B ? ABC_State[3] : ABC_State[2];
				WireSelect(1);
				break;
			case 3:
				C = !C;
				C_indicator.sprite = C ? ABC_State[5] : ABC_State[4];
				WireSelect(2);
				break;
		}
	}
	private void WireSelect(int selectedWire)
	{
		switch (selectedWire)
		{
			case 0:
				Wires[0].SetActive(A);
				break;
			case 1:
				Wires[1].SetActive(B);
				break;
			case 2:
				Wires[2].SetActive(C);
				Wires[3].SetActive(!C);
				break;
		}

		LogicGate();
	}
	private void LogicGate()
	{
		AB = A && B;

		if (AB && !C)
		{
			WinCondition();
		}
		else
		{
			if (AB)
			{
				
				Wires[0].SetActive(!A);
				Wires[1].SetActive(!B);
				Wires[4].SetActive(AB);
			}
			else
			{
				Wires[0].SetActive(A);
				Wires[1].SetActive(B);
				Wires[4].SetActive(AB);
			}

			

		}
		

	}
	

}
