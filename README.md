# RpgGame
## 1. 팀 노션
https://teamsparta.notion.site/05-7d92263c51464846802a02830480b4e4
## 2. 실행 방법
~~~C#
git clone https://github.com/UnityA05/RpgGame.git
cd RpgGame
dotnet run
~~~
## 3. 파일 및 클래스 분류
#### 1) Program.cs → MainPage.cs → CharacterSelect.cs
- 프로그램의 시작. 인트로 페이지와 캐릭터 선택 및 생성 페이지.
#### 2) Character.cs (Player.cs, Monster.cs)
- 플레이어블 캐릭터와 출현하는 몬스터의 제작을 위한 인터페이스.
#### 3) Job.cs (HumanJob.cs, MonsterJob.cs)
- 캐릭터와 몬스터의 직업에 관한 인터페이스.
- 캐릭터는 직업(전사, 법사, 궁수, 도적, Deprived-가지지 못한 자), 몬스터는 종류
#### 4) Skill.cs (HumanSkill.cs, MonsterSkill.cs)
- 캐릭터와 몬스터의 스킬
#### 5) Inventory.cs Shop.cs Item.cs ItemCode.cs
- 게임 내 아이템과 관련된 클래스.
- 아이템 목록, 각 아이템의 속성 관리(직업별 착용, 부위, 악세서리, 포션), 인벤토리와 상점
#### 6) Dungeon.cs
- 몬스터와 전투를 하는 공간.
- 랜덤한 몬스터가 소환되며 플레이어는 공격, 방어, 스킬 등의 선택지를 사용해 몬스터를 처치하고 보상을 받는다.
#### 7) ConsoleUI.cs
- 코드 편의성을 위한 클래스.


## 4. 파트 분배
#### 차요한 (팀장)
* Dungeon.cs, Character.cs, Program.cs, 팀 노션 설명 및 순서도
#### 이소이
* MainPage.cs,  CharacterSelect.cs, ConsoleUI.cs, Program.cs, README.md
#### 김도현
* Player.cs Monster.cs Job.cs-(HumanJob.cs MonsterJob.cs) Skill.cs-(HumanSkill.cs MonsterSkill.cs)
#### 이하택
* Inventory.cs Shop.cs Item.cs ItemCode.cs

  
