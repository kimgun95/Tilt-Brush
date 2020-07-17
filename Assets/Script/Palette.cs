using System.CodeDom.Compiler;
using UnityEngine;
using Valve.VR;

//왼손의 컨트롤러에서 
//트랙패드를 클릭했을 경우
//트랙패드의 위치값을 가져온다.
//만약 트랙패드의 오른쪽을 터치한경우
//-90도씩 회전값을 누적하여 오른쪽방향으로 팔레트가 회전한다.
//만약 트랙패드의 왼쪽을 터치한 경우
//+90도씩 회전값을 누적하여 왼쪽방향으로 팔레트가 회전한다.

public class Palette : MonoBehaviour
{
    //왼손, 오른손, 트랙패드 터치여부, 터치 위치
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackpadPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //트랙패드를 클릭했을 경우
        if (trackPad.GetStateDown(leftHand))
        {
            //트랙패드의 위치값을 가져온다.
            Vector2 touchPos = trackPadPosition.GetAxis(leftHand);
            //만약 트랙패드의 오른쪽을 터치한경우 -> 0.2는 책272p 참고
            if (touchPos.x >= 0.2f)
            {
                //-90도씩 회전값을 누적하여 오른쪽방향으로 팔레트가 회전한다. 
                iTween.RotateAdd(gameObject, iTween.Hash("y", -90.0f
                                                         , "time", 0.2f
                                                         , "easetype"
                                                         , iTween.EaseType.easeOutBounce));
            }
            //만약 트랙패드의 왼쪽을 터치한 경우
            else if (touchPos.x <= -0.2f)
            {
                //+90도씩 회전값을 누적하여 왼쪽방향으로 팔레트가 회전한다.
                iTween.RotateAdd(gameObject, iTween.Hash("y", 90.0f
                                                         , "time", 0.2f
                                                         , "easetype"
                                                         , iTween.EaseType.easeOutBounce));
            }

            else if (touchPos.y >= 0.2f)
            {
                //print(Draw.Instance.lineWidth);
                if(Draw.Instance.lineWidth < 1.0f)
                {
                    Draw.Instance.lineWidth += 0.003f;
                }
                //print(Draw.Instance.lineWidth);

            }
            else if (touchPos.y <= -0.2f)
            {
                //print(Draw.Instance.lineWidth);
                if(Draw.Instance.lineWidth > 0.0001f)
                {
                    Draw.Instance.lineWidth -= 0.003f;
                }
                //print(Draw.Instance.lineWidth);

            }
        }

    }
}
