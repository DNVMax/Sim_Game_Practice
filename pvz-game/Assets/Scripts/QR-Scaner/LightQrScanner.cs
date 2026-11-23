using UnityEngine;
using UnityEngine.Splines;

public class LightQrScanner : MonoBehaviour
{
    public Transform targetObject; // Ссылка на главный объект

    void Update()
    {
        if (targetObject != null)
        {
            // Копируем вращение один в один
            transform.rotation = targetObject.rotation;
        }
    }
}
