## 2020.02.17
- 유니티 특수폴더
  - Editor폴더에 있는 것 먼저 컴파일
  - Editor - 런타입이 아닌 에디터스크립트로 판단 - 특수용도로만 만들기에 자주 사용하지말 것!
  - Resources - 메모리를 다 로딩함 - 최적화할때 여기다 넣지말 것!

- 싱글톤 - 존재하는 이유가 단 하나여야만할때 사용한다.
  - 이러한 디자인패턴 - 알고 쓸 것.

왜 쓸거냐 늘 생각하기.

##### 기본형태
메모리
1. 공간 -> 자료형 기본형
2. int float string bool / 연산자 ()
3. array[]
4. for / while
5. if

//stack에 생성 - 값형
struct
{

}


//heap에 생성 - 참조형
커스텀 자료형 = class
class(형태 / 게임에서의 직업)

```cs
class Adata
{
	public Adata()
 {
 
 }
  ~Adata()
  {

  }
}
```

* 데이터모델링
  * 기획서든 이미지든 모든 정보를 명사하고 동사나눈다.
  * 명사 - class / 동사 - class 메소드

##### 상속성

플레이어가 있다. 플레이어는 hp가 있다.
몬스터도 있고 몬스터도 hp가 있다.
player is character
monster is character
```cs
class character
{
	protected(밖에서는 접근 못하지만 안에서는 상속 가능하도록) int hp;
}
class player : character
{
	
}

class monster : character
{
	
}
```

```cs
//캡슐화 - 좋은 상품은 단순한데 잘 작동하는 것이다!
class test
{
	public void do()
	{
		//남이 써도 죽지않게 예외 처리한다.
	}

	private void dohidden()
	{
		//내부에서 내가 처리 할꺼, 딴 사람은 몰라야 됨.
	}
	
	public int hp
	{
		get; // hp;
		set; // hp = 12;
	}

	public int gold
	{
		get
		{
			return gold;
		}
	}
}
```
* 다형성 - 부모형식 공간에 자식 자료를 넣을 수 있다. / 그리고 실행시 알아서 부모와 자식 함수를 실행한다.
"반복문이 단순화"

```cs
class Base
{
	public virtual void Do()
	{
	}

}

class Child : Base
{
	public override void Do()
	{
		
	}
```
}
