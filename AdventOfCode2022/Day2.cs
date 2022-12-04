using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
	public class Day2
	{

		public int myTotalScore;
		public int myTotalScoreBasedonRoundEnds;


		public void Puzzle1()
		{
			myTotalScore = 0;
			string[] strategyData = ReadStrategyData();
			CheckGameRound(strategyData);
		}

		public void Puzzle2()
		{
			myTotalScoreBasedonRoundEnds = 0;
			string[] strategyData = ReadStrategyData();
			CheckGameRoundEnd(strategyData);
		}

		private string[] ReadStrategyData()
		{
			string dataSource = "E:\\source\\AdventOfCode2022\\AdventOfCode2022\\PuzzlesInput\\Day2.txt";
			string[] strategyData = File.ReadAllLines(dataSource);
			return strategyData;
		}

		private void CheckGameRound(string[] data)
		{
			int myShapePoint = 0;
			int winPoint = 6;
			int drawPoint = 3;
			int myRoundScore = 0;
			
			foreach (string round in data)
			{
				bool isMyWin = false;
				bool isRoundDraw = false;
				char[] shapes = round.Trim().ToCharArray();
				char opponentShape;
				char myShape;
				opponentShape= shapes[0];
				myShape= shapes[2];
				switch (myShape)
				{
					case 'X':
						myShapePoint = 1;
						break;
					case 'Y':
						myShapePoint = 2;
						break;
					case 'Z':
						myShapePoint = 3;
						break;
					default:
						break;
				}

				isRoundDraw = CheckRoundDraw(opponentShape, myShape);
				
				if (isRoundDraw)
				{
					myRoundScore = drawPoint + myShapePoint;
				}
				else
				{
					isMyWin = CheckResult(myShape, opponentShape);

					if (isMyWin)
					{
						myRoundScore = myShapePoint + winPoint;
					}
					else
					{
						myRoundScore = myShapePoint;
					}
				}

				myTotalScore += myRoundScore;
				myRoundScore = 0;
			}
			
		}

		private bool CheckResult(char myShape, char opponentShape)
		{
			bool win = false;

			switch (myShape)
			{
				case 'X':
					if (opponentShape == 'C')
					{
						win = true;
					}
					else
					{
						win = false;
					}
					break;
				case 'Y':
					if (opponentShape == 'A')
					{
						win = true;
					}
					else
					{
						win = false;
					}
					break;
				case 'Z':
					if (opponentShape == 'B')
					{
						win = true;
					}
					else
					{
						win = false;
					}
					break;
				default:
					break;
			}

			return win;
		}

		private bool CheckRoundDraw(char opponentShape, char myShape)
		{
			bool isRoundDraw = false;
			
			if (opponentShape == 'A' && myShape == 'X')
			{
				isRoundDraw = true;
			}
			else if (opponentShape == 'B' && myShape == 'Y')
			{
				isRoundDraw = true;
			}
			else if (opponentShape == 'C' && myShape == 'Z')
			{
				isRoundDraw = true;
			}
			else
			{
				isRoundDraw = false;
			}

			return isRoundDraw;
		}


		private void CheckGameRoundEnd(string[] data)
		{
			int winPoint = 6;
			int drawPoint = 3;
			int myRoundScore = 0;
			int myShapePoint = 0;
			foreach (string round in data)
			{
				char[] shapes = round.Trim().ToCharArray();
				char opponentShape;
				char roundEndCode;
				opponentShape = shapes[0];
				roundEndCode = shapes[2];
				switch (roundEndCode)
				{
					case 'X':
						if (opponentShape == 'A')
						{
							myShapePoint = 3;
						}
						else if (opponentShape == 'B')
						{
							myShapePoint = 1;
						}
						else if (opponentShape == 'C')
						{
							myShapePoint = 2;
						}

						myRoundScore = myShapePoint;
						break;
					case 'Y':
						if (opponentShape == 'A')
						{
							myShapePoint = 1;
						}
						else if (opponentShape == 'B')
						{
							myShapePoint = 2;
						}
						else if (opponentShape == 'C')
						{
							myShapePoint = 3;
						}
						myRoundScore = myShapePoint + drawPoint;
						break;
					case 'Z':
						if (opponentShape == 'A')
						{
							myShapePoint = 2;
						}
						else if (opponentShape == 'B')
						{
							myShapePoint = 3;
						}
						else if (opponentShape == 'C')
						{
							myShapePoint = 1;
						}
						myRoundScore = myShapePoint + winPoint;
						break;						
				}

				myTotalScoreBasedonRoundEnds += myRoundScore;
				myRoundScore = 0;
			}
			
		}
	}
}
