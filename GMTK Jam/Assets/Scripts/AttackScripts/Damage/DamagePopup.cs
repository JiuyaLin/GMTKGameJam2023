using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static void Create(Vector3 position, int damage, float timeIn, bool isPlayer) {
        Transform popUp = GameAssets.i.enemyPopup;
        if (!isPlayer) popUp = GameAssets.i.playerPopup;

        Transform damageT = Instantiate(popUp, position, Quaternion.identity);
        DamagePopup damagePopup = damageT.GetComponent<DamagePopup>();
        damagePopup.Setup(damage, timeIn);
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Camera trackedCamera;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        trackedCamera = FindAnyObjectByType<Camera>();
    }

    public void Setup(int damage, float timeIn) {
        textMesh.SetText(damage.ToString());
        disappearTimer = timeIn;
    }

    private void Update()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0) {
            float disappearSpeed = 1f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy(gameObject);
            }
        }

        float moveYSpeed = 3f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        transform.rotation = trackedCamera.transform.rotation;
    }
}