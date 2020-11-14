using System;

namespace ParseATP.Models
{
	public class PlayerModel
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public int Weight { get; set; }
		public int Height { get; set; }

		public PlayerModel(string name, int age, int weight, int height)
		{
			Name = name;
			Age = age;
			Weight = weight;
			Height = height;
		}

		public void Output()
		{
			Console.WriteLine("Name: " + Name);
			Console.WriteLine("Age: " + Age);
			Console.WriteLine("Weight: " + Weight);
			Console.WriteLine("Height: " + Height);
			Console.WriteLine();
		}
	}
}
