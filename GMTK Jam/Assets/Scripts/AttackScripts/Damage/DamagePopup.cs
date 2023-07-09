using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static void Create(Vector3 position, int damage, double timeIn, bool isPlayer) {
        Transform popUp = GameAssets.i.enemyPopup;
        if (!isPlayer) popUp = GameAssets.i.playerPopup;

        Transform damageT = Instantiate(popUp, position, Quaternion.identity);
        DamagePopup damagePopup = damageT.GetComponent<DamagePopup>();
        damagePopup.Setup(damage, timeIn);
    }

    private TextMeshPro textMesh;
    private float startTime;
    private double time = -1;

    private void Awake()
    {
        startTime = Time.time;
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damage, double timeIn) {
        textMesh.SetText(damage.ToString());
        startTime = Time.time;
        time = timeIn;
    }

    void Update()
    {
        if (Time.time - startTime > time && time != -1) {
            Destroy(gameObject);
        }
    }
}
