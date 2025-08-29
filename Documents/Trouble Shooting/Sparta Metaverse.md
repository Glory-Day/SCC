# Sparta Metaverse 프로젝트 트러블 슈팅 문서

### Json 파싱 오류 해결

기존의 Newtonsoft Json 직렬화와는 달리 Unity `JsonUtility` 클래스를 사용하여 직렬화를 하는 과정에서 문제가 발생하였습니다. 클래스를 배열로 직렬화하여 저장하는 과정에서 직렬화가 안되는 문제가 생겨 이를 해결했던 과정들을 아래와 같이 서술합니다.

#### 해결

Unity `JsonUtility` 클래스의 역직렬화는 클래스를 배열 타입으로는 역직렬화를 할 수 없어서 `Wrapper` 클래스를 따로 생성하여 이를 해결하였습니다.

- **기존의 코드**
  
  ```csharp
  [Serializable]
  public class StageData
  {
    public int score
  }
  
  ...
  
  var data = new [] { new StageData(), new StageData() };
                  
  JsonSerializer.Serialize(GetPersistentDataPath(nameof(StageData)), data);
  ```
- **수정된 코드**
  
  ```csharp
  [Serializable]
  public class StageData
  {
    public int score
  }
  
  [Serializable]
  public class StageDataWrapper
  {
    public StageData[] wrapper;
  }
  
  ...
  
  var data = new StageDataWrapper
  {
     Wrapper = new [] { new StageData(), new StageData() }
  };
                  
  JsonSerializer.Serialize(GetPersistentDataPath(nameof(StageData)), data);
  ```
