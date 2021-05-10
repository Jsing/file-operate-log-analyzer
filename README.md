특정 프로세스의 파일 API 호출 로그를 분석하여 파일 API 사용 상의 오류를 찾습니다. FileOperateLogAnalyzer 는 아래의 오류 케이스를 찾아서 리포팅합니다.
- 멀티쓰레드 환경에서 닫힌 파일에 대한 쓰기 시도를 하는 케이스
- 512개 이상의 파일을 동시에 열고 쓰기를 시도하는 케이스 

파일 API 로그는 Process Monitor 를 통해 수집합니다. ( [Process Monitor v3.70 바로가기](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) )

## 개발하게 된 이유 
- MFC 기반의 서버 프로그램이 아래와 같은 오류 메시지를 남기며 약 1달에 한 번 가량 비정상 종료되기 시작했다.

![](https://images.velog.io/images/joosing/post/a43108da-c2cb-4f50-9c65-8dad44ad0dbd/image.png)
- 해당 오류 메시지를 출력하는 fwrite.c 프레임워크 코드를 확인한 결과, 닫힌 파일에 대해 쓰기를 시도하면 발생할 수 있는 오류로 확인 되었다. 

![](https://images.velog.io/images/joosing/post/267da9d2-1698-4883-b1ae-27046dcc6b84/image.png)
- 그리고 관련된 이론적 배경을 찾기위해 MSDN 을 탐색하던 중, [C Runtime에서는 512개 이상의 파일을 동시에 열 수 없는 제약](https://docs.microsoft.com/en-us/cpp/c-runtime-library/reference/setmaxstdio?view=msvc-160&viewFallbackFrom=vs-2019#:~:text=By%20default%2C%20up%20to%20512,use%20of%20the%20_setmaxstdio%20function)이 있음을 알았고 의도적으로 512개의 파일을 동시에 열고 쓰기를 시도하는 경우 동일한 오류창과 함께 문제가 재현됨을 확인하였다. 
- 그래서 Process Monitor를 통해 프로그램 실행 중 파일 API 호출 로그를 수집했고, 7만여 라인의 로그를 분석하기 위한 자동화된 소프트웨어를 개발하게 되었따. 


## 실행방법
- Process Monitor 프로그램을 통해 런타임 File API 호출 로그를 수집하고 CSV 파일로 내보내기 한다. 관련 로그 수집 및 내보내기 방법은 다음 글을 참고한다. 
- FileOperateLogAnalyzer 를 실행한다.
- Start 버튼을 선택하고 내보내기한 CSV 파일을 선택한다.
- 결과를 확인한다. 

## 개발환경 
- C++, MFC 
- Visual Studio 2019
- .NET Framework 4.7.2 
