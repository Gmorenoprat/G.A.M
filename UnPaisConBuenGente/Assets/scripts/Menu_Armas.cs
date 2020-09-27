using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Menu_Armas : MonoBehaviour
{
    //string Name = "";
    Texture2D icon;
    GameObject weapon;
   

  public List<Weapons> weapons;
  public Vector2 buttonSize;
  public float spread = 100;
  public GUIStyle iconStyle ;

  private int selectedWeapon;
  private bool guiSettingsApplied;
  private float fxClamp;
  private float curFXFloat;
  private Rect buttonRect;

// Start is called before the first frame update
void Start()
    {
        weapons = GetComponentsInChildren<Weapons>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
