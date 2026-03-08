using UnityEngine;

public class RoofVisibility : MonoBehaviour
{
    public void SetVisible(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}