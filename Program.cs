using System.Collections.Generic;
using GameControllerLib;
using PlayerLib;
using CardLib;
using CardSuitLib;
using CardRankLib;
using RuleLib;
using IPlayerLib;
using DisplayLib;

namespace Program
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Display start = new Display();
			GameController gamecontroller = new GameController();
			gamecontroller.CreatePlayers();

			gamecontroller.DealHoleCards();
			//gamecontroller.StartBetting();
			//Console.ReadLine();

			gamecontroller.DealCommunityCards();
			gamecontroller.StartBetting();
			Console.ReadLine();

			gamecontroller.DealTurnCard();
			gamecontroller.StartBetting();
			Console.ReadLine();

			gamecontroller.DealRiverCard();
			gamecontroller.StartBetting();
			Console.ReadLine();

			Console.ReadLine();
		}
	}
}
