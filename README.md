# RpgGame
## 1. 팀 노션
https://teamsparta.notion.site/05-7d92263c51464846802a02830480b4e4
## 2. 실행 방법
~~~C#
git clone https://github.com/UnityA05/RpgGame.git
cd RpgGame
dotnet run
~~~
## 3. 초기 설계

필요 클래스
- MainPage.cs
    - 이동 메소드## 전투시작, 상태보기, 아이템사용
- Player.cs
    - 상태반환
    - 상태저장
    - 레벨업
- Character.cs (interface) ## 플레이어, 몬스터
    - 레벨, 이름, 직업, 체력, 공격력, 방어력, 골드, MP(스킬 기능 추가할 경우)
- Make.cs
- Monster.cs
    - 상태반환
    - 상태저장
- Dungeon.cs
    - 스테이지(층별→몬스터가 많아진다)
    - 몬스터생성
    - 승리판단
    - 전투요소
        - 스킬사용 # 플레이어만
        - 치명타
        - 회피
        - 회복기능
        - 방어 # 방어력에 따라 피해 경감
        - 보상 - 경험치, 골드, 아이템
- Inventory.cs ##회복, 장착
    - 인벤토리 요소 반환
    - 인벤토리 아이템 추가
    - 인벤토리 아이템 사용
    - 아이템 장착
- Shop.cs
    - 상점 목록 출력
    - 상점 구매
    - 상점 판매
- ConsoleUI.cs
    - 출력을 용이하게 (매개변수로 색상,문자열 전달) (precision 지정 → 한글일 경우를 핸들링)
- Item.cs
    - 아이템 코드 형식
