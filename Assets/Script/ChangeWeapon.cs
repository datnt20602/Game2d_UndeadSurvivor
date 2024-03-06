using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
	public GameObject[] weapons; // Mảng chứa các game object của các vũ khí
	private int selectedWeapon = 0; // Vũ khí đang được chọn
	private Vector3[] originalPositions; // Mảng lưu trữ vị trí gốc của các vũ khí

	void Start()
	{
		

		// Lưu trữ vị trí gốc của các vũ khí
		originalPositions = new Vector3[weapons.Length];
		for (int i = 0; i < weapons.Length; i++)
		{
			if (weapons[i] != null)
			{
				originalPositions[i] = weapons[i].transform.position;
			}
		}
		SelectWeapon(); 
	}

	void Update()
	{
		// Kiểm tra sự kiện nhấn các số trên bàn phím để chọn vũ khí
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
			SelectWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length >= 2)
		{
			selectedWeapon = 1;
			SelectWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length >= 3)
		{
			selectedWeapon = 2;
			SelectWeapon();
		}
	}

	void SelectWeapon()
	{
		
		for (int i = 0; i < weapons.Length; i++)
		{
			if (weapons[i] != null)
			{
				
				if (i == selectedWeapon)
				{
					Vector3 newPosition = originalPositions[i];
					newPosition.x -= 1f; 
					weapons[i].transform.position = newPosition;
				}
				
				else
				{
					weapons[i].transform.position = originalPositions[i];
				}
			}
		}
	}
}
