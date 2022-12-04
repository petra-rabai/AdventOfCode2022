using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
	public class Day1
	{
		public int maxCalorie;
		public int topThreeCaloriesTotal;
		
		public void Puzzle1()
		{
			int[] calories = ReadCalories();
			int[] totalCaloriesPerElf = CountCaloriesPerElf(calories);

			maxCalorie = SeekMaxCalorie(totalCaloriesPerElf);
			
		}

		public void Puzzle2()
		{
			int[] calories = ReadCalories();
			int[] totalCaloriesPerElf = CountCaloriesPerElf(calories);

			topThreeCaloriesTotal = SeekTopTreeCaloriesAndSumIt(totalCaloriesPerElf);
		}

		private int[] ReadCalories()
		{
			string dataSource = "E:\\source\\AdventOfCode2022\\AdventOfCode2022\\PuzzlesInput\\Day1.txt";
			string emptyLine = "";
			
			string[] data = File.ReadAllLines(dataSource);
			int[] calorieData = new int[data.Length];

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != emptyLine)
				{
					calorieData[i] = Convert.ToInt32(data[i]);
				}
				else 
				{
					calorieData[i] = 0;
				}
			}   
			
			
			return calorieData;
		}

		private int SeekMaxCalorie(int[] calories)
		{
			return calories.Max();
		}

		private int SeekTopTreeCaloriesAndSumIt(int[] calories)
		{
			int sum = 0;
			int[] sortedCalories = calories.OrderByDescending(x => x).ToArray();
			
			for (int i = 0; i < 3; i++)
			{
				sum += sortedCalories[i];
			}

			return sum;
		}

		private int[] CountCaloriesPerElf(int[] calories) 
		{
			int[] caloriesPerElf = new int[calories.Length];
			int caloriePerElf = 0;
			int count = 0;

			foreach (int item in calories)
			{
				if (item != 0)
				{
					caloriePerElf += item;
				}

				if (item == 0)
				{
					caloriesPerElf[count] = caloriePerElf;
					caloriePerElf = 0;
					count++;
				}
					
			}
				
			return caloriesPerElf;
		}
	}
}
