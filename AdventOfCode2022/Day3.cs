using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
	public class Day3
	{

		public int sumOfpriority;

		public void Puzzle1()
		{
			sumOfpriority = 0;
			string[] itemList = ReadItemData();
			string[] firstComaprtment = new string[itemList.Length];
			string[] secondComaprtment = new string[itemList.Length];
			char sharedItemType = ' ';
			GetCompartments(itemList,firstComaprtment, secondComaprtment);
			sharedItemType = GetSharedItemType(firstComaprtment, secondComaprtment);
		}

		public void Puzzle2()
		{
			
		}

		private string[] ReadItemData()
		{
			string dataSource = "E:\\source\\AdventOfCode2022\\AdventOfCode2022\\PuzzlesInput\\Day3.txt";
			string[] itemData = File.ReadAllLines(dataSource);
			return itemData;
		}

		private void GetCompartments(string[] itemList, string[] firstList, string[] secondList)
		{
			int itemCount = 0;

			foreach (string item in itemList)
			{
				int itemLengthHalfCount = item.Length / 2;
				string itemFirstHalf = item.Substring(0, itemLengthHalfCount);
				firstList[itemCount] = itemFirstHalf;
				secondList[itemCount] = item.Substring(itemLengthHalfCount);
				itemCount++;
			}
		}

		private char GetSharedItemType(string[] firstList, string[] secondList)
		{
			char sharedItemType = ' ';

			for (int i = 0; i < firstList.Length; i++)
			{
				char[] firstListItem = firstList[i].ToCharArray();
				char[] secondListItem = secondList[i].ToCharArray();
				
				if (secondList[i].Contains(firstList[i]))
				{
					sharedItemType = secondList[i];
				}
				
			}
			return sharedItemType;
		}

	}
}
