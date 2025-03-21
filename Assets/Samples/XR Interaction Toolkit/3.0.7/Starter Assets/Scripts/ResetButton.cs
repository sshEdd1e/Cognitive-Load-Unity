using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Dictionary<GameObject, (Vector3, Quaternion)> initialPositions = new Dictionary<GameObject, (Vector3, Quaternion)>();
    public GameObject[] objectsToTrack;
    public Button resetButton;
    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        foreach (GameObject obj in objectsToTrack)
        {
            initialPositions[obj] = (obj.transform.position, obj.transform.rotation);
            resetButton.gameObject.SetActive(false);
        }

        resetButton.onClick.AddListener(ResetObjects);
    }

    // Update is called once per frame
    public void ResetObjects()
    {
        foreach (var obj in initialPositions.Keys)
        {
            if (obj != null)
            {
                obj.transform.position = initialPositions[obj].Item1;
                obj.transform.rotation = initialPositions[obj].Item2;
                obj.SetActive(true);
            }
        }

        resetButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }
    public void DeleteObject(string toDestroyObjTag)
    {
        foreach (GameObject obj in objectsToTrack)
        {
            Debug.Log("A comparar: " + obj.tag);
            Debug.Log("A destruir: " + toDestroyObjTag);
            if (obj.CompareTag(toDestroyObjTag))
            {
                obj.SetActive(false);
            }
        }
    }
}
