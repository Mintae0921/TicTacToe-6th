# Gemini CLI로 생성된 Tic Tac Toe Unity 프로젝트

이 프로젝트는 Gemini CLI를 사용하여 Tic Tac Toe 게임을 구현했습니다. 다음은 프로젝트의 주요 구성 요소 및 Unity에서 게임을 실행하기 위한 지침입니다.

## 구현된 스크립트

-   **GameManager.cs**: 게임의 전반적인 로직을 관리합니다. 현재 플레이어 턴, 보드 상태, 승리 조건 확인, 무승부 확인, 게임 리셋 등의 기능을 포함합니다.
-   **Cell.cs**: Tic Tac Toe 보드의 각 셀을 나타냅니다. 클릭 이벤트를 처리하고 GameManager에 알리며, 셀의 'X' 또는 'O' 표시를 업데이트합니다.
-   **Board.cs**: Cell 프리팹을 사용하여 3x3 그리드에 셀을 인스턴스화하고 배치합니다. GameManager로부터 업데이트 요청을 받아 모든 셀의 표시를 갱신합니다.

## Unity Scene 설정 지침

게임을 Unity에서 실행하려면 다음 단계를 따르세요:

1.  **새 Unity 씬 생성**: 새 씬을 생성하고 `Assets/01. Scenes/` 폴더에 "TicTacToeGame"으로 저장합니다.

2.  **Canvas 설정**:
    *   Hierarchy에서 마우스 오른쪽 버튼을 클릭하고 `UI` > `Canvas`를 선택합니다.
    *   Canvas GameObject를 선택하고 Inspector에서 `Render Mode`를 `Screen Space - Camera`로 설정한 다음, `Main Camera`를 `Render Camera` 슬롯에 드래그합니다.
    *   `UI Scale Mode`를 `Scale With Screen Size`로, `Reference Resolution`을 1920x1080과 같은 적절한 값으로 설정합니다.

3.  **BoardPanel 및 GridLayoutGroup 생성**:
    *   Canvas 아래에 `UI` > `Panel`을 생성하고 "BoardPanel"로 이름을 변경합니다.
    *   "BoardPanel"의 `Rect Transform`을 화면에 맞게 조정합니다.
    *   `Add Component`를 클릭하고 `Grid Layout Group`을 추가합니다.
    *   `Grid Layout Group`을 다음과 같이 설정합니다:
        *   `Constraint`: `Fixed Column Count`, `Constraint Count`: `3`.
        *   `Cell Size`와 `Spacing`을 적절히 조정합니다 (예: Cell Size 100x100).
        *   `Child Alignment`를 `MiddleCenter`로 설정합니다.
    *   "BoardPanel"에 `Board.cs` 스크립트를 추가합니다.

4.  **Cell 프리팹 생성**:
    *   "BoardPanel" 아래에 `UI` > `Button`을 생성하고 "CellButton"으로 이름을 변경합니다.
    *   기본 `Text (Legacy)` 자식 요소를 제거하고, "CellButton"에 마우스 오른쪽 버튼을 클릭하여 `UI` > `Text`를 추가합니다.
    *   새 `Text` 자식 요소를 선택하고 텍스트를 비우고, `Font Size`를 크게 (예: 80-100) 설정하고, `Alignment`를 `Center`와 `Middle`로 설정합니다.
    *   "CellButton"에 `Cell.cs` 스크립트를 추가합니다.
    *   "CellButton"을 `Assets/03. Prefabs/` 폴더로 드래그하여 프리팹으로 만듭니다.
    *   Hierarchy에서 "CellButton" 인스턴스를 삭제합니다.

5.  **GameManager GameObject 생성**:
    *   Hierarchy에서 `Create Empty`를 선택하고 "GameManager"로 이름을 변경합니다.
    *   이 "GameManager" GameObject에 `GameManager.cs` 스크립트를 추가합니다.

6.  **Inspector에서 스크립트 연결**:
    *   "BoardPanel" GameObject를 선택합니다. `Board (Script)` 컴포넌트의 `Cell Prefab` 슬롯에 `CellButton` 프리팹을 드래그합니다.
    *   `Cell Parent` 슬롯에 "BoardPanel" 자체를 드래그합니다.
    *   "GameManager" GameObject를 선택합니다. `GameManager (Script)` 컴포넌트의 `Status Text` 슬롯에 "StatusText" GameObject를 드래그합니다 (아래 7단계 참조).

7.  **Reset 버튼 추가**:
    *   Canvas 아래에 `UI` > `Button`을 추가하고 "ResetButton"으로 이름을 변경합니다.
    *   "ResetButton"의 `On Click()` 이벤트 섹션에서 `+` 버튼을 클릭합니다.
    *   `Object` 슬롯에 "GameManager" GameObject를 드래그합니다.
    *   `Function` 드롭다운에서 `GameManager` > `ResetGame()`을 선택합니다.

8.  **Status Text 추가**:
    *   Canvas 아래에 `UI` > `Text`를 추가하고 "StatusText"로 이름을 변경합니다. 이 텍스트는 현재 턴 또는 게임 상태 (승리/무승부)를 표시합니다.
    *   "GameManager" GameObject를 선택하고 Inspector에서 "StatusText" GameObject를 `GameManager (Script)` 컴포넌트의 `Status Text` 슬롯에 드래그합니다.

이제 Unity Editor에서 플레이 버튼을 눌러 Tic Tac Toe 게임을 플레이할 수 있습니다.
