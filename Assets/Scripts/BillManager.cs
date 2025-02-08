using UnityEngine;
using DG.Tweening;

public class BillManager : MonoBehaviour
{
    public GameObject billPrefab;
    public Transform billParent;

    void OnEnable()
    {
        GameEvents.OnClick += SpawnBill;
    }

    void OnDisable()
    {
        GameEvents.OnClick -= SpawnBill;
    }

    public void SpawnBill(Vector2 position)
    {
        GameObject bill = Instantiate(billPrefab, position, Quaternion.identity, billParent);
        AnimateBill(bill);
    }

    private void AnimateBill(GameObject bill)
    {
        Vector2 randomOffset = new Vector2(Random.Range(-400, 400), Random.Range(1200, 1400));
        bill.transform.DOMove((Vector2)bill.transform.position + randomOffset, 0.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                bill.transform.DOMoveY(-Screen.height, 1.5f).SetEase(Ease.InQuad)
                    .OnComplete(() => Destroy(bill));
            });
    }
}
