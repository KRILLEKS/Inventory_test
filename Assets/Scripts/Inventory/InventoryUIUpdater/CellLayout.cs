using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// we won't waste productivity on dozens .GetComponent<> during runtime
// we can use OnValidate or OnInit(Odin) if we don't want to set components by hand
public class CellLayout : MonoBehaviour
{
   public GameObject LockedGO;
   public GameObject UnlockedGO;
   public RawImage StackableIconRawImage;
   public RawImage UnstackableIconRawImage;
   public TextMeshProUGUI AmountTMP;

   [HideInInspector] public bool HasItem = false;
}
