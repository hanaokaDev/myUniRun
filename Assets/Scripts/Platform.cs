using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() {
        // 발판을 리셋하는 처리
        stepped = false;

        for(int i = 0; i < obstacles.Length; i++)
        {
            // 1/3 확률로 장애물 활성화
            if (Random.Range(0, 3) == 0) 
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        if(collision.collider.CompareTag("Player") && !stepped)
        {
            // 중복 점수 추가를 방지하기 위해 stepped 변수를 사용
            Debug.Log("Score!");
            stepped = true;
            GameManager.instance.AddScore(1);
        }
        else
        {
            Debug.Log("No Score!");
        }
    }
}