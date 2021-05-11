## 개요
본 프로그램은 특정 프로세스의 **런타임 파일 API 호출 로그를 분석하여 API 사용 상의 오류**를 찾습니다. 구체적으로 아래의 오류 케이스를 찾아서 리포팅합니다.
- 512개 이상의 파일을 동시에 열고 쓰기를 시도하는 케이스 
- 파일을 열고 닫지 않는 케이스 
- 닫힌 파일에 대한 쓰기 시도를 하는 케이스

## 만든 이유 
유지보수 계약을 맺고있던 서버 프로그램(C++, MFC)이 아래와 같은 오류 메시지를 남기며 간헐적으로 **비정상 종료**되기 시작했습니다. 

![](https://images.velog.io/images/joosing/post/a43108da-c2cb-4f50-9c65-8dad44ad0dbd/image.png)

확인해 보니 서버 프로그램은 C Runtime 파일 라이브러리를 사용하고 있었고, Debug 모드로 빌드된 실행파일을 사용하고 있었습니다. 

그리고 해당 오류 메시지를 출력하는 fwrite.c 프레임워크 코드를 확인한 결과, **닫힌 파일에 대해 쓰기를 시도**할 때 발생할 수 있다는 Assertion 문구를 확인할 수 있었습니다. 

![](https://images.velog.io/images/joosing/post/267da9d2-1698-4883-b1ae-27046dcc6b84/image.png)

또한 관련된 이론적 배경을 찾기위해 MSDN 을 탐색하던 중, [C Runtime에서는 512개 이상의 파일을 동시에 열 수 없는 제약](https://docs.microsoft.com/en-us/cpp/c-runtime-library/reference/setmaxstdio?view=msvc-160&viewFallbackFrom=vs-2019#:~:text=By%20default%2C%20up%20to%20512,use%20of%20the%20_setmaxstdio%20function)이 있음을 알았고 의도적으로 **512개의 파일을 동시에 열고 쓰기를 시도하는 경우** 동일한 오류창과 함께 문제가 재현됨을 확인하였습니다. 

그래서 Process Monitor를 통해 프로그램 실행 중 파일 API 호출 로그를 수집했고, **7만여 라인의 로그를 분석**하기 위한 자동화된 소프트웨어를 개발하게 되었습니다. 


## 프로그램 입력
프로그램의 입력은 [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) (Windows Sysinternals 제공)를 통해 수집한 런타임 파일 API 호출 로그입니다. Process Monitor 에서 로그 수집 시 아래의 API 만 필터링하여 수집하면 됩니다. [Process Monitor 사용법](https://velog.io/@joosing/Process-Monitor-ProcMon.exe-%ED%8A%B9%EC%A0%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%A8%EC%9D%B4-%EB%9F%B0%ED%83%80%EC%9E%84%EC%97%90-%ED%98%B8%EC%B6%9C%ED%95%98%EB%8A%94-Windows-API-%EB%AA%A8%EB%8B%88%ED%84%B0%EB%A7%81-%ED%95%98%EA%B8%B0)은 링크를 참고하시면 도움이  됩니다. 
- CreateFile, CloseFile, WriteFile, ReadFile



## 실행
이제 Start 버튼을 클릭하고, Process Monitor 로그 파일을 선택하면 자동으로 분석 작업이 시작되고 결과를 리포팅해줍니다. 

## 결과화면
- [ Output ] : 동시에 열린 파일 개수 최대치 출력
- [ 열리고 닫히지 않은 파일 ] : 열리고 닫히지 않은 파일 목록 및 전체 개수 출력
- [ 닫힌 파일에 대한 쓰기 시도 ] : 닫힌 파일에 대한 쓰기 시도한 파일 목록 및 전체 개수 출력

![image](https://user-images.githubusercontent.com/34666301/117637316-a713e900-b1bc-11eb-84db-102d3c3f6925.png)


## 개발환경 
- C++, MFC 
- Visual Studio 2019
- .NET Framework 4.7.2 

[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2FJsing%2Ffile-operate-log-analyzer&count_bg=%2379C83D&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)
