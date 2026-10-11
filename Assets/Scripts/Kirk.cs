

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 1. 定義移動目標點陣列 (往前走 -> 上跳 -> 下跳到終點)
    public Vector2[] points = new Vector2[] {
        new Vector2(3f, 0f),   // 往前走
        new Vector2(6f, 3f),   // 上跳最高點
        new Vector2(9f, 0f)    // 下跳至終點
    };

    private int currentIndex = 0;
    public float moveSpeed = 3.0f;

    void Update()
    {
        // 若已走完陣列內所有點則停止
        if (currentIndex >= points.Length) return;

        // 目前目標點
        Vector2 target = points[currentIndex];
        Vector2 currentPos = transform.position;

        // 2. 利用 Vector 減法計算方向向量 (講義 3-9-2)
        Vector2 dir = target - currentPos;

        // 3. 判斷是否抵達目標點 (利用 dir.magnitude 距離)
        if (dir.magnitude < 0.1f)
        {
            currentIndex++; // 切換到陣列的下一個動作點
        }
        else
        {
            // 4. 每影格平滑累加位移向量 (講義 3-9-3)
            Vector2 step = dir.normalized * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)step;
        }
    }
}
