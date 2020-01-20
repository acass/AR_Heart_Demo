using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DelayInt : MonoBehaviour {

    public CanvasGroup mCanvasGroup;

	void Start () {
		
		StartCoroutine(TestCoroutine());
	}
	
	IEnumerator TestCoroutine(){
		
		yield return new WaitForSeconds(3);

        mCanvasGroup.DOFade (0, 2);
	}
}