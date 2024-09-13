using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace StudentManage
{
	[Serializable]
	class Student
	{
		public string Name { get; set; }
		public string ID { get; set; }
		public string PhoneNum { get; set; }

		//public string[] Department { get; set; } = new string[3];
		public string[] Subject { get; set; } = new string[3];
		public int[] Score { get; set; } = new int[3];
		public string[] SubjectGrade { get; } = new string[3];
		public int TotalScore { get; set; }
		public double AverageScore { get; set; }
		public int GradeRank { get; }

		// 등록금 관련 변수
		public int DepartFee { get; set; }

		public int ResgisterFee { get; set; }
		public int Scholarship { get; set; }
		// public int DifferenceFee { }

		public bool bEnroll;
		// 졸업생 추가, 연도로 구별
		public bool bGraduating;



		public override string ToString()
		{
			return "Name : " + Name + "\t ID : " + ID + "\t PhoneNum : " + PhoneNum;
		}
	}
	class Program
	{
		static List<Student> sList = new List<Student>(); // 학생 정보 
		static List<Student> gList = new List<Student>(); // 성적 정보
														  // static List<Student> mList = new List<Student>();

		static void Main(string[] args)
		{
			// Console.WriteLine("Hello World!");
			//List<Student> sList = new List<Student>();
			//List<Student> gList = new List<Student>();


			Stream fs3 = new FileStream("a.dat", FileMode.Open);
			BinaryFormatter bf3 = new BinaryFormatter();
			sList = (List<Student>)bf3.Deserialize(fs3);

			Stream fs4 = new FileStream("b.dat", FileMode.Open);
			BinaryFormatter bf4 = new BinaryFormatter();
			gList = (List<Student>)bf4.Deserialize(fs4);

			fs3.Close();
			fs4.Close();

			//sList.Add(new Student() { Name = "일졸업", ID = "20171001", PhoneNum = "010-2017-0001", bGraduating = true, DepartFee = 0, ResgisterFee = 0, Scholarship = 0 });
			//sList.Add(new Student() { Name = "홍길동", ID = "20241001", PhoneNum = "010-1234-0001", bEnroll = true, DepartFee = 500, ResgisterFee = 600, Scholarship = 0 });
			//sList.Add(new Student() { Name = "김철수", ID = "20241002", PhoneNum = "010-1234-0002", bEnroll = true, DepartFee = 500, ResgisterFee = 400, Scholarship = 100 });
			//sList.Add(new Student() { Name = "일휴학", ID = "20241003", PhoneNum = "010-1234-1111", bEnroll = false, DepartFee = 500, ResgisterFee = 0, Scholarship = 0 });
			//sList.Add(new Student() { Name = "이졸업", ID = "20172001", PhoneNum = "010-2017-0002", bGraduating = true, DepartFee = 0, ResgisterFee = 0, Scholarship = 0 });
			//sList.Add(new Student() { Name = "이영희", ID = "20242001", PhoneNum = "010-1234-0003", bEnroll = true, DepartFee = 450, ResgisterFee = 400, Scholarship = 50 });
			//sList.Add(new Student() { Name = "김영수", ID = "20242002", PhoneNum = "010-1234-0004", bEnroll = true, DepartFee = 450, ResgisterFee = 300, Scholarship = 150 });
			//sList.Add(new Student() { Name = "삼졸업", ID = "20173001", PhoneNum = "010-2017-0003", bGraduating = true, DepartFee = 0, ResgisterFee = 0, Scholarship = 0 });
			//sList.Add(new Student() { Name = "박영철", ID = "20243001", PhoneNum = "010-1234-0005", bEnroll = true, DepartFee = 400, ResgisterFee = 300, Scholarship = 0 });
			//sList.Add(new Student() { Name = "삼휴학", ID = "20243002", PhoneNum = "010-1234-3333", bEnroll = false, DepartFee = 400, ResgisterFee = 0, Scholarship = 0 });

			//gList.Add(new Student() { ID = "20171001", Score = new int[] { 88, 77, 48 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20241001", Score = new int[] { 88, 77, 48 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20241002", Score = new int[] { 76, 65, 54 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20241003", Score = new int[] { 100, 100, 100 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20172001", Score = new int[] { 100, 100, 100 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20242001", Score = new int[] { 65, 99, 96 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20242002", Score = new int[] { 55, 100, 86 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20173001", Score = new int[] { 27, 99, 75 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20243001", Score = new int[] { 27, 99, 75 }, Subject = new string[] { "C", "C++", "C#" } });
			//gList.Add(new Student() { ID = "20243002", Score = new int[] { 100, 100, 100 }, Subject = new string[] { "C", "C++", "C#" } });

			//foreach (Student sl in sList)
			//    WriteLine(sl);


			MainMenu();



		}

		// 조회 함수
		static void MainMenu()
		{
			string num;

			while (true)
			{
				WriteLine("========== 메뉴 ==========");
				WriteLine("1. 학생 정보 조회");
				WriteLine("2. 등록금 조회");
				WriteLine("3. 성적 조회");
				WriteLine("4. 정보 입력");
				WriteLine("5. 정보 수정");
				WriteLine("6. 종료");

				Write(">> 선택 메뉴 번호 입력 : ");
				num = ReadLine();

				switch (num)
				{
					case "1":
						// 학생 정보 조회 함수 O
						SearchStudentInfo();
						break;
					case "2":
						// 등록금 조회 함수 0
						SearchRegisterFee();
						break;
					case "3":
						// 성적 조회 함수 O
						SearchGrade();
						break;
					case "4":
						// 등록 메뉴 함수
						RegiestMenu();
						break;
					case "5":
						// 수정 메뉴 함수
						RevisionMenu();
						break;
					case "6":
						// 종료 함수
						FileSave();
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;
				}
			}
		}

		static void FileSave()
		{
			Stream fs3 = new FileStream("a.dat", FileMode.Create);
			BinaryFormatter bf1 = new BinaryFormatter();
			bf1.Serialize(fs3, sList);

			Stream fs4 = new FileStream("b.dat", FileMode.Create);
			BinaryFormatter bf2 = new BinaryFormatter();
			bf2.Serialize(fs4, gList);


			fs3.Close();
			fs4.Close();
		}

		// 학생 정보 조회 함수
		static void SearchStudentInfo()
		{
			string num;

			while (true)
			{
				WriteLine("========== 학생 정보 조회 ==========");
				WriteLine("1. 전체 조회");
				WriteLine("2. 재학생 조회");
				WriteLine("3. 휴학생 조회");
				WriteLine("4. 졸업생 조회");
				WriteLine("5. 이전 메뉴");
				Write(">> 선택 메뉴 번호 입력 : ");
				num = ReadLine();

				switch (num)
				{
					case "1":
						TotalSearch();
						break;
					case "2":
						// 재학생 조회
						EnrollSearch();
						break;
					case "3":
						// 휴학생 조회
						NotEnrollSearch();
						break;
					case "4":
						// 졸업생 조회
						GraduatedSearch();
						break;
					case "5":
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;

				}
			}

		}
		// 등록금 조회 함수
		static void SearchRegisterFee()
		{
			string num;
			while (true)
			{
				WriteLine("========== 등록금 조회 ==========");
				WriteLine("1. 전체 등록금 조회");
				WriteLine("2. 미납자 조회");
				WriteLine("3. 이전 메뉴");
				Write(">> 선택하실 번호를 입력하세요 : ");

				num = ReadLine();

				switch (num)
				{
					case "1":
						// 전체 등록금 조회
						TotalSearchRegisterFee();
						break;
					case "2":
						// 미납자 조회
						// 초과하여 낸 사람 처리
						SearchNotPay();
						break;
					case "3":
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;

				}
			}
		}

		// 성적 조회 함수
		static void SearchGrade()
		{
			string num;
			while (true)
			{
				WriteLine("========== 성적 조회 ==========");
				WriteLine("1. 전체 성적 조회");
				WriteLine("2. 학과별 성적 조회");
				WriteLine("3. 이전 메뉴");
				Write(">> 선택하실 번호를 입력하세요 : ");

				num = ReadLine();

				switch (num)
				{
					case "1":
						// 전체 성적 조회
						SearchTotalScore();
						break;
					case "2":
						// 학과별 성적 조회
						SearchDepartmentScore();
						break;
					case "3":
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;
				}
			}
		}

		// 등록 메뉴 함수
		static void RegiestMenu()
		{
			string num;
			while (true)
			{
				WriteLine("========== 입력 메뉴 ==========");
				WriteLine("1. 학생 입력");
				WriteLine("2. 등록금 입력");
				WriteLine("3. 성적 입력");
				WriteLine("4. 이전 메뉴");
				Write(">> 선택하실 번호를 입력하세요 : ");

				num = ReadLine();

				switch (num)
				{
					case "1":
						// 학생 등록 함수
						break;
					case "2":
						// 등록금 수납 함수
						break;
					case "3":
						// 성적 입력
						break;
					case "4":
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;

				}
			}
		}

		// 수정 메뉴 함수
		static void RevisionMenu()
		{
			string num;

			while (true)
			{
				WriteLine("========== 수정 메뉴 ==========");
				WriteLine("1. 휴학 철회");
				WriteLine("2. 휴학 등록");
				WriteLine("3. 성적 정보 수정");
				WriteLine("4. 이전 메뉴");
				Write(">> 선택하실 번호를 입력하세요 : ");

				num = ReadLine();

				switch (num)
				{
					case "1":
						// 휴학 철회 함수
						RevisionNotEnrollStudent();
						break;
					case "2":
						// 휴학 등록 함수
						RevisionEnrollStudent();
						break;
					case "3":
						// 성적 정보 수정
						RevisionScore();
						break;
					case "4":
						return;
					default:
						WriteLine("잘못된 번호입니다. 다시 입력하세요.");
						WriteLine();
						break;
				}
			}
		}

		// 성적 수정 함수
		static void RevisionScore()
		{
			string num;
			string subject;
			int score;
			WriteLine("=====================성적 수정=====================");
			Write(">> 학번 입력 :");

			num = ReadLine();
			WriteLine(">> 수정 과목 번호 입력 ");
			WriteLine("1. C \n2. C++ \n3.C#");
			subject = ReadLine();

			Write(">> 수정할 점수 입력 : ");
			score = int.Parse(ReadLine());

			// 입력받은 학번과 맞는 정보 찾기
			var id = from glist in gList
					 where (glist.ID == num && glist.Score.Length == 3)
					 select glist;

			WriteLine("학번        과목        점수");
			WriteLine("===========================================================");

			foreach (Student selId in id)
			{
				switch (subject)
				{
					case "1":
						selId.Score[0] = score;
						WriteLine(/*selId.Name + "    " +*/ selId.ID + "    " + selId.Subject[0] + "    " + selId.Score[0]);
						break;
					case "2":
						selId.Score[1] = score;
						WriteLine(/*selId.Name + "    " + */selId.ID + "    " + selId.Subject[1] + "    " + selId.Score[1]);
						break;
					case "3":
						selId.Score[2] = score;
						WriteLine(/*selId.Name + "    " + */selId.ID + "    " + selId.Subject[2] + "    " + selId.Score[2]);
						break;
					default:
						WriteLine("잘못된 번호 입력");
						break;
				}


			}

			WriteLine("===================================================");
			WriteLine(">> 점수 변경 완료");

		}

		// 휴학 등록 함수
		static void RevisionEnrollStudent()
		{
			string num;

			WriteLine("=====================휴학 등록=====================");
			Write(">> 학번 입력 :");
			num = ReadLine();

			// 입력받은 학번과 맞는 정보 찾기
			var id = from slist in sList
					 where (slist.ID == num && slist.bEnroll)
					 select slist;


			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("===================================================");

			foreach (Student selId in id)
			{
				WriteLine(selId.Name + "           " + selId.ID + "          " + selId.PhoneNum);
				selId.bEnroll = false;
				//selId.ResgisterFee = 0;
				//selId.Scholarship = 0;
			}

			WriteLine("===================================================");
			WriteLine(">> 휴학 등록 완료");
			WriteLine();
		}

		// 휴학 철회 함수
		static void RevisionNotEnrollStudent()
		{
			string num;

			WriteLine("=====================휴학 철회=====================");
			Write(">> 학번 입력 :");
			num = ReadLine();

			// 입력받은 학번과 맞는 정보 찾기
			var id = from slist in sList
					 where (slist.ID == num && !slist.bEnroll)
					 select slist;


			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("===================================================");

			foreach (Student selId in id)
			{
				WriteLine(selId.Name + "           " + selId.ID + "          " + selId.PhoneNum);

				// 기존 데이터에 변경해야함 
				foreach (Student sl in sList)
				{
					if (selId.ID == sl.ID)
					{
						sl.bEnroll = true;
						sl.ResgisterFee = 0;
						sl.Scholarship = 0;
					}
				}
			}

			WriteLine("===================================================");
			WriteLine(">> 휴학 철회 완료");
			WriteLine();

		}

		// 전체 성적 조회
		static void SearchTotalScore()
		{
			WriteLine("=============전체 성적 조회=============");
			WriteLine("이름         학번            C     등급     C++    등급    C#    등급    평균점수");
			foreach (Student gl in gList)
			{
				foreach (Student sl in sList)
				{
					if (gl.ID == sl.ID && sl.bEnroll)
					{
						Write(sl.Name + "       " + gl.ID + "       ");
						for (int i = 0; i < 3; i++)
						{
							//Write(gl.Subject[i]);
							Write(gl.Score[i] + "       ");

							gl.TotalScore += gl.Score[i];

							if (gl.Score[i] > 90)
								gl.SubjectGrade[i] = "A";
							else if (gl.Score[i] > 80)
								gl.SubjectGrade[i] = "B";
							else if (gl.Score[i] > 70)
								gl.SubjectGrade[i] = "C";
							else if (gl.Score[i] > 60)
								gl.SubjectGrade[i] = "D";
							else gl.SubjectGrade[i] = "F";

							Write(gl.SubjectGrade[i] + "     ");
							//WriteLine();
						}
						gl.AverageScore = gl.TotalScore / 3;
						WriteLine(gl.AverageScore + "점");
						// CalGrade();

					}

				}

			}


		}

		// 학과별 성적 계산 함수
		static void CalScore()
		{
			int cnt = 0;
			double departmentAvg = 0.0, departmentTotalScore = 0.0, grade = 0.0;
			List<double> dbList = new List<double>();

			foreach (Student gl in gList)
			{
				foreach (Student sl in sList)
				{
					if (gl.ID == sl.ID && sl.bEnroll)
					{
						if (gl.ID[4] == '1')
						{

							Write(sl.Name + "       " + gl.ID + "       ");
							for (int i = 0; i < 3; i++)
							{
								//Write(gl.Subject[i]);
								Write(gl.Score[i] + "       ");

								gl.TotalScore += gl.Score[i];

								if (gl.Score[i] > 90)
									gl.SubjectGrade[i] = "A";
								else if (gl.Score[i] > 80)
									gl.SubjectGrade[i] = "B";
								else if (gl.Score[i] > 70)
									gl.SubjectGrade[i] = "C";
								else if (gl.Score[i] > 60)
									gl.SubjectGrade[i] = "D";
								else gl.SubjectGrade[i] = "F";

								Write(gl.SubjectGrade[i] + "     ");

							}
							gl.AverageScore = gl.TotalScore / 3;
							Write(gl.AverageScore + "점");
							cnt++;
							// CalGrade();
							WriteLine();
							// 학과별  점수 구하기
							departmentTotalScore += gl.AverageScore;
							dbList.Add(gl.AverageScore);

							// 1등 구하기
							grade = (from obj in dbList
										 //orderby obj ascending
									 select obj).Max();

						}
					}
				}

				//

			}

			// 학과별 평균 구하기
			departmentAvg = departmentTotalScore / cnt;
			WriteLine("====================================================================================");
			WriteLine("학과 평균 : " + departmentAvg + "점");
			WriteLine();
			WriteLine("===================================학과수석=========================================");
			WriteLine("이름       학번      평균 점수");
			foreach (Student gl in gList)
			{
				foreach (Student sl in sList)
				{
					if (grade == gl.AverageScore && gl.ID == sl.ID && sl.bEnroll)
						Write(sl.Name + "    " + gl.ID + "      " + grade + "점");
				}
			}

			WriteLine();
		}

		// 학과별 성적 조회
		static void SearchDepartmentScore() // 전체 점수 , 평균, 1등
		{
			string num;

			WriteLine("============학과별 성적 조회============");
			WriteLine("1. 컴퓨터공학과");
			WriteLine("2. 전자과");
			WriteLine("3. 정보처리학과");
			Write(">> 조회하실 학과를 입력하세요 : ");

			num = ReadLine();
			WriteLine();
			WriteLine("==================================학과별 성적 조회==================================");
			WriteLine("이름         학번            C     등급     C++    등급    C#    등급    평균점수");
			WriteLine("====================================================================================");
			switch (num)
			{
				case "1":
					CalScore();
					break;
				case "2":
					CalScore();
					break;
				case "3":
					CalScore();
					break;
				default:
					WriteLine("잘못된 번호입니다. 다시 입력하세요.");
					WriteLine();
					break;
			}

		}

		// 학생 정보 조회
		static void EnrollSearch()
		{
			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("====================================================");
			foreach (Student sl in sList)
			{
				if (sl.bEnroll)
					WriteLine(sl.Name + "           " + sl.ID + "          " + sl.PhoneNum);
			}

			WriteLine("====================================================");

		}

		static void NotEnrollSearch()
		{
			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("====================================================");
			foreach (Student sl in sList)
			{
				if (!sl.bEnroll && !sl.bGraduating)
					WriteLine(sl.Name + "           " + sl.ID + "          " + sl.PhoneNum);
			}

			WriteLine("====================================================");
		}

		static void GraduatedSearch()
		{
			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("====================================================");
			foreach (Student sl in sList)
			{
				if (sl.bGraduating)
					WriteLine(sl.Name + "           " + sl.ID + "          " + sl.PhoneNum);
			}

			WriteLine("====================================================");
		}

		static void TotalSearch()
		{
			WriteLine("이름               학번              휴대폰 번호");
			WriteLine("====================================================");
			foreach (Student sl in sList)
			{
				WriteLine(sl.Name + "           " + sl.ID + "          " + sl.PhoneNum);
			}

			WriteLine("====================================================");
		}

		// 등록금 조회
		static void TotalSearchRegisterFee()
		{
			WriteLine("===============================등록금 조회===============================");
			WriteLine("이름               학번           수납금       장학금     학과 등록금    잔금");
			WriteLine("=========================================================================");
			foreach (Student sl in sList)
			{
				if (sl.bEnroll)
					WriteLine(sl.Name + "           " + sl.ID + "          " + sl.ResgisterFee + "          " + sl.Scholarship
						+ "          " + sl.DepartFee + "          " + (sl.DepartFee - (sl.ResgisterFee + sl.Scholarship)));

			}

			WriteLine("=========================================================================");

		}

		// 미납자 조회함수
		static void SearchNotPay()
		{
			WriteLine("===============미납자 조회===============");
			WriteLine("이름         학번        미납금");
			WriteLine("=========================================");
			foreach (Student sl in sList)
			{
				if (sl.bEnroll && (sl.DepartFee - (sl.ResgisterFee + sl.Scholarship)) > 0)
					WriteLine(sl.Name + "       " + sl.ID + "     " + (sl.DepartFee - (sl.ResgisterFee + sl.Scholarship)));
			}
			WriteLine();
		}

	}
}
