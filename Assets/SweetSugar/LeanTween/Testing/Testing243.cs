using UnityEngine;

public class Testing243 : MonoBehaviour
{
    public GameObject cube1;
    public Light lightInScene;

    public RectTransform imageRectTransform;

    //	void Start () {
    //		cube1.transform.localPosition = new Vector3(0, 10, -10);
    //		LeanTween.move(cube1, new Vector3(0, 0, -10), 1f).setEaseInOutQuart().setOnUpdate( ( Vector3 val )=>{
    //			Debug.Log("val:"+val);	
    //		}).setOnComplete(() => {
    //			Debug.Log("cube1 end pos:"+cube1.transform.position);
    //		});
    //	}

    void Start()
    {
        LeanTween.sequence().append(LeanTween.scale(cube1, Vector3.one * 3f, .1f)).append(LeanTween.scale(cube1, Vector3.one * 5.6f, .2f));
        LeanTween.sequence().append(LeanTween.value(lightInScene.gameObject, (float f) => lightInScene.range = f, 8, 12, .1f)).append(LeanTween.value(lightInScene.gameObject, (float f) => lightInScene.range = f, 12, 8, .2f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
