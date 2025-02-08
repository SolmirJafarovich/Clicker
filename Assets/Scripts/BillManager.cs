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
        AnimateBill(bill, billParent);
    }

    private void AnimateBill(GameObject bill, Transform upgradeIndicator)
    {
        RectTransform billTransform = bill.GetComponent<RectTransform>();

        if (billTransform == null) return;

        float randomXOffset = Random.Range(-100f, 100f);
        float randomRotation = Random.Range(-180f, 180f); 
        float flightDuration = 0.6f; 
        float fallDuration = 1.2f; 


        Vector2 targetPosition = new Vector2(
            billTransform.anchoredPosition.x + randomXOffset,
            upgradeIndicator.position.y + 400
        );


        billTransform.DOAnchorPos(targetPosition, flightDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {

            billTransform.DOAnchorPosY(-Screen.height * 0.2f, fallDuration)
                    .SetEase(Ease.InQuad)
                    .OnComplete(() => Destroy(bill));
            });

        billTransform.DORotate(new Vector3(0, 0, randomRotation), flightDuration + fallDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear);
    }

}
