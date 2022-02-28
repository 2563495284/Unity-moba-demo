using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  class MoveCamera : MonoBehaviour {

    public float cSpeed = 10;

    private float endZ = -20;
    //whitescreen
    private Image iWhiteScreen;
    private float wAlpha;
    private GameObject whitescreen;
    //title
    private Image iTitle;
    private float tAlpha;
    private GameObject title;
    //pressanykey
    private Image iPressAnyKey;
    private float pakAlpha;
    private GameObject pressAnyKey;
    private bool isIn;
    //渐入渐出速度
    public float alphaSpeed_w;
    public float alphaSpeed_t;
    public float alphaSpeed_pak;
    void Start ()
	{
		//whitescreen组件获取
		whitescreen=GameObject.Find("Canvas/whitescreen");
		iWhiteScreen = whitescreen.GetComponent<Image>();
		//title组件获取
		title = GameObject.Find("Canvas/title");
		iTitle = title.GetComponent<Image>();
		//pressanykey组件获取
		pressAnyKey = GameObject.Find("Canvas/pressanykey");
		iPressAnyKey = pressAnyKey.GetComponent<Image>();
		isIn = false;
		//渐入渐出速度
		alphaSpeed_w = 0.003f;
		alphaSpeed_t = 0.001f;
		alphaSpeed_pak = 0.003f;
		//对透明度赋初值
		wAlpha = iWhiteScreen.color.a;
		tAlpha = iTitle.color.a;
		pakAlpha = iPressAnyKey.color.a;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < endZ) {//还没有达到目标位置，需要移动
            transform.Translate( Vector3.forward*cSpeed*Time.deltaTime);
        }
        
        imageInOrOut(alphaSpeed_w,ref wAlpha,iWhiteScreen,true);
        if (wAlpha<0.3f)
        {
	        imageInOrOut(alphaSpeed_t,ref tAlpha,iTitle,false);
        }

        if (tAlpha>=1f)
        { 
	        imageInOrOut(alphaSpeed_pak,ref pakAlpha,iPressAnyKey,isIn);
	        if (pakAlpha>=1f)
	        { 
		        isIn = true;
	        }

	        if (pakAlpha<=0f)
	        { 
		        isIn = false; 
	        }
        }
	}
/// <summary>
///屏幕渐入渐出效果
/// </summary>
/// <param name="speed">渐入渐出速度</param>
/// <param name="alpha">Image透明度</param>
/// <param name="image">image组件</param>
/// <param name="isInOrOut">bool值1，true淡入，false淡出</param>
	void imageInOrOut(float speed,ref float alpha,Image image,bool isInOrOut)
	{
		//alpha递减或递增
		alpha = isInOrOut ? alpha - speed : alpha + speed;
		//设置图片的透明度
		Color color = image.color;
		color.a = alpha;
		image.color = color;
		//到零后取消
		if (alpha<=0)
		{
			whitescreen.SetActive(false);
		}
	}
}
