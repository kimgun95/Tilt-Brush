# Tilt-Brush

Steam VR과 Vive Pro hmd를 이용하여 Tilt Brush를 구현


기간
2020.7.15 ~ 16 (2일)

팀원 : 나포함 3명

기능
1. 색깔별 Brush 기능
2. Brush의 굵기 조절 기능
2. 그린 그림을 지워주는 Erase기능


구현 방법
1. 책 : 절대강좌! 유니티 VR/AR 을 참고하여 기본 기능을 구현하였다.
2. Brush의 굵기는 Controller의 TouchPad의 위, 아래를 click하여 구현하였다.
2. Erase기능은 Controller의 Grab을 GetState를 통해 구현하였고
   Line Renderer를 선이 아닌 점으로 만들어서 점을 각각의 충돌체로 구현 후 충돌 시 삭제되게 구현하였다.

시도했지만 실패한 기능
1. 네온 느낌의 Brush기능
2. 그린 그림에 색을 덮어 씌우는 기능
3. Line Renderer를 움직이는 전깃줄 느낌으로 구현

아쉬운점
1. Erase기능을 위해 Line Renderer를 Line Renderer라고 부르지 못하게 되었다. (점으로 구현했으니...)
2. 스스로 시간 투자를 많이 못하는 상황이라 너무너무 아쉬웠다...
