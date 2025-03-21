using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetValueFromDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Image displayImage;
    [SerializeField] private Sprite[] orderImages;
    private OrderChecker orderChecker;

    private void Start()
    {
        orderChecker = FindAnyObjectByType<OrderChecker>();
        if (orderChecker == null)
        {
            Debug.LogError("OrderChecker não encontrado");
        }
    }
    public void GetDropdownValue()
    {
        if (orderChecker != null)
        {
            int pickedEntryIdx = dropdown.value;
            if (pickedEntryIdx >= 1 && pickedEntryIdx < orderImages.Length+1)
            {
                displayImage.sprite = orderImages[pickedEntryIdx-1];
                orderChecker.SetOrder(pickedEntryIdx);
                Debug.Log(pickedEntryIdx);
            }
        }
    }
}
