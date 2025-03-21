using System.Collections.Generic;
using UnityEngine;

public class OrderChecker : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField]
    private GameObject mesa;

    private bool nivelZero = false;
    private bool nivelUm = false;
    private bool nivelDois = false;

    private Renderer mesaRenderer;
    private ResetButton resetBtn;
    private StartButton startBtn;

    private Queue<(ObjectProperties.ShapeType, ObjectProperties.ColorType)> correctOrder =
        new Queue<(ObjectProperties.ShapeType, ObjectProperties.ColorType)>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        resetBtn = FindAnyObjectByType<ResetButton>();
        startBtn = FindAnyObjectByType<StartButton>();
        mesaRenderer = mesa.GetComponent<Renderer>();
    }

    public void SetOrder(int dropdownIdx)
    {
        correctOrder.Clear();
        nivelZero = false;
        nivelUm = false;
        nivelDois = false;
        Debug.Log("Nova ordem definida com indice: " + dropdownIdx);
        if (dropdownIdx == 1)
        {
            Debug.Log("Nivel 0");
            nivelZero = true;

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else if (dropdownIdx == 2)
        {
            Debug.Log("Nivel 1");
            nivelUm = true;

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else if (dropdownIdx == 3)
        {
            Debug.Log("Nivel 2");
            nivelDois = true;

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else if (dropdownIdx == 4)
        {
            Debug.Log("Nivel 3");
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else if (dropdownIdx == 5)
        {
            Debug.Log("Nivel 4");
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else if (dropdownIdx == 6)
        {
            Debug.Log("Nivel 5");
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Yellow));

            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Blue));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Cube, ObjectProperties.ColorType.Red));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Pyramid, ObjectProperties.ColorType.Green));
            correctOrder.Enqueue((ObjectProperties.ShapeType.Sphere, ObjectProperties.ColorType.Yellow));
        }
        else
        {
            Debug.Log("Index incorreto");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectProperties obj = other.GetComponent<ObjectProperties>();

        if ((obj != null && correctOrder.Count > 0) || nivelZero)
        {
            var expected = correctOrder.Peek();

            if (obj.shape == expected.Item1 || nivelZero)
            {
                if(obj.color == expected.Item2 || nivelZero || nivelUm)
                {
                    Debug.Log("Objeto correto! Avançando...");
                    correctOrder.Dequeue(); // Remove da fila se estiver correto
                    resetBtn.DeleteObject(other.gameObject.tag);
                    audioSource.PlayOneShot(correctSound);
                    mesaRenderer.material.color = Color.green;
                }
                else
                {
                    Debug.Log("Objeto errado! Tente novamente.");
                    audioSource.PlayOneShot(incorrectSound);
                    mesaRenderer.material.color = Color.red;
                }
            }
            else if (obj.color == expected.Item2 || nivelZero)
            {
                if (obj.shape == expected.Item1 || nivelZero || nivelDois)
                {
                    Debug.Log("Objeto correto! Avançando...");
                    correctOrder.Dequeue(); // Remove da fila se estiver correto
                    resetBtn.DeleteObject(other.gameObject.tag);
                    audioSource.PlayOneShot(correctSound);
                    mesaRenderer.material.color = Color.green;
                }
                else
                {
                    Debug.Log("Objeto errado! Tente novamente.");
                    audioSource.PlayOneShot(incorrectSound);
                    mesaRenderer.material.color = Color.red;
                }
            }
            else
            {
                Debug.Log("Objeto errado! Tente novamente.");
                audioSource.PlayOneShot(incorrectSound);
                mesaRenderer.material.color = Color.red;
            }
        }
        if (correctOrder.Count == 0)
        {
            startBtn.StopCounting();
            audioSource.PlayOneShot(winSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Objeto removido!");
        mesaRenderer.material.color = Color.white;
    }
}
