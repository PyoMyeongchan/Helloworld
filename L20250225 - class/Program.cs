using System;
using System.IO;

namespace L20250225___class
{
    // 자료 갯수가 자주 변하지 않는 곳에서 쓰임.
    // 임의 접근 빨라야되는거
    // List<T>

    // 자료구조 - 어디에 사용할지에 따라 다르다.
    // 해싱, 해싱 충돌 / AVL tree / redblack tree
    // aes256
    // 암호화 되어 있으면 의미 있는 시간안에 푼다.

    // exception - 설계 - 에러도 객체다 - class
    // try, catch - file, network 혹은 게임 다 완성된 이후에나 쓴다

    class Program
    {

        // OOP = ERROR도 객체 -> 예외
        static void Main(string[] args)
        {
            try
            {
                //Engine.load();
                //Engine.Run();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                StreamWriter sw = new StreamWriter("log.txt");
                sw.WriteLine(e.Message);
                sw.WriteLine(e.StackTrace);
                sw.Flush();
                sw.Close();

            }
            finally
            { 
                // 파일 닫기
                // 네트워크 끊기
                // 메모리 정리
                // 텍스쳐 언로딩
            }
        }
    }

    // 작은 메모리 덤프 파일 읽기
    // 일반적인 개발 -> 프로그램 -> try, catch -> 추천
    // 게임 -> try, catch 일반적으로 X
    // unity core engine = c++ / contnent = c#
}
