using System.Collections.Generic;
using System.Linq;
using IPlayerLib;
using PlayerLib;
using CardLib;
using CardRankLib;
using CardSuitLib;
using RuleLib;
using ScoreLib;

namespace GameControllerLib
{
	class GameController
	{
		private int _pot;
		private int _inputNumber;
		private IList<IPlayer> _players;
		private Dictionary<IPlayer, List<Card>> _holeCards;
		private List<Card> _tableCards;

		public GameController()
		{
			_players = new List<IPlayer>();
			_holeCards = new Dictionary<IPlayer, List<Card>>();
			_tableCards = new List<Card>();
		}

		public void CreatePlayers()
                {
                        Console.Write("Please enter the number of players (2-8): ");
                        _inputNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"OK. There will be {_inputNumber} players playing.");
                        for (int i = 0; i < _inputNumber; i++)
                        {
                                Player player = new Player();
				Console.WriteLine("Next player,");
				Console.Write("Enter your name: ");
                                player.SetName(Console.ReadLine());
				//string names = player.GetName();
                                Console.Write("Enter your ID: ");
                                player.SetID(Console.ReadLine());
				//string IDs = player.GetID();
				Console.Write("Enter your initial contribution for the ante: ");
				player.SetChips(int.Parse(Console.ReadLine()));
				//int chips = player.GetChips(Convert.ToInt32(Console.ReadLine()));
				_players.Add(player);
                        }
//                        foreach (var player in _players)
//                        {
//                                Console.WriteLine(player.GetName());
//                        } //-OK
                }
		
//		public int GatherChips()
//		{
//			return allchips = chips1 + chips2 + chips3;
//		}

		public Card GenerateCard()
                {
                        Random random = new Random();
                        Array valuesSuit = Enum.GetValues(typeof(CardSuit));
                        Array valuesRank = Enum.GetValues(typeof(CardRank));

                        int indexSuit = random.Next(valuesSuit.Length);
                        CardSuit tempSuit = (CardSuit)valuesSuit.GetValue(indexSuit);

                        int indexRank = random.Next(valuesRank.Length);
                        CardRank tempRank = (CardRank)valuesRank.GetValue(indexRank);
			Card card = new Card();
			card.SetCardSuit(tempSuit);
			card.SetCardRank(tempRank);
			return card;
		}

		public void DealHoleCards()
                {
                        Card card1 = GenerateCard();	
			Card card2 = GenerateCard();
			while (card1.GetCardSuit() == card2.GetCardSuit() && card1.GetCardRank() == card2.GetCardRank())
			{
				card2 = GenerateCard();
			}
			List<Card> cards = new List<Card> { card1, card2 };

			foreach (var item in _players)
			{
				_holeCards.Add(item, cards);
			}

			foreach (KeyValuePair<IPlayer, List<Card>> kvp in _holeCards)
			{
				Console.WriteLine(kvp.Key.GetName());
			}
              	}

                public void DealCommunityCards()
                {
			Console.WriteLine($"Dealing The Flop to players . . .");
			Console.WriteLine($"\n=+=+=+=+=+=+=+=+=+= THE FLOP =+=+=+=+=+=+=+=+=+=");
			for (int i = 0; i < 3; i++)
			{
				_tableCards.Add(GenerateCard());
			}
			foreach (var comcards in _tableCards)
			{
				Console.WriteLine($"{comcards.GetCardSuit()} {comcards.GetCardRank()}");
			}
                        
			Console.ReadLine();
                }

		public void DealTurnCard()
                {
                        Console.WriteLine($"Dealing The Turn to players . . .");
			Console.WriteLine($"\n=+=+=+=+=+=+=+=+=+= THE TURN =+=+=+=+=+=+=+=+=+=");
                        _tableCards.Add(GenerateCard());
//                        foreach (var comcards in _tableCards)
//                        {
//                                Console.WriteLine(comcards.suit);
//                        }
			Console.ReadLine();
                }

                public void DealRiverCard()
                {
                        Console.WriteLine($"Dealing The River to players . . .");
			Console.WriteLine($"\n=+=+=+=+=+=+=+=+=+= THE RIVER =+=+=+=+=+=+=+=+=+=");
                        _tableCards.Add(GenerateCard());
//			foreach (var comcards in _tableCards)
//                        {
//                                Console.WriteLine(comcards.rank);
//                        }
//			Console.ReadLine();
                }

		public void StartBetting()
        	{
			Console.Write("Choose your option: [1] Bet, [2] Check: ");
                        char option = Convert.ToChar(Console.Read());
            		for (int i = 0; i < _inputNumber; i++)
			{
			switch (option)
                        {
				case '1':
					goto statement2;
                                	break;
				case '2':
					goto statement3;
					break;
                        }
			}
//				while (option == '1')
//				{
//					Console.Write("You have taken 'Bet' option. Please enter the amount you want to bet: ");
//					int pot = Console.Read();
//					Console.WriteLine($"This player has bet {pot} chips. Now the following players are going to choose 'Fold', 'Call' or 'Raise'");
//					Console.Write("Next player, choose your option: [1] Fold, [2] Call, [3] Raise ");
//					char option2 = Convert.ToChar(Console.Read());
//					switch (option2)
//					{
//						case '1':
//	  						Console.WriteLine("You have taken 'Fold' option.");
//		    					break;
//						case '2':
//							Console.WriteLine("You have taken 'Call' option.");
//							break;
//						case '3':
//							Console.WriteLine("You have taken 'Raise' option. Please enter the new amount: ");
//							Console.Read();
//							break;
//					}
//				}
				statement3:
			for (int i = 0; i < _inputNumber; i++)
			{
				Console.WriteLine("You have taken 'Check' option.");
			}
statement2:
			for (int i = 0; i < _inputNumber; i++)
			{
				Console.Write("You have taken 'Bet' option. Please enter the amount you want to bet: ");
                                int pot = Console.Read();
                                Console.WriteLine($"This player has bet {pot} chips. Now the following players are going to choose 'Fold', 'Call' or 'Raise'");
				Console.Write("Next player, choose your option: [1] Fold, [2] Call, [3] Raise ");
                                char option2 = Convert.ToChar(Console.Read());
                                switch (option2)
                                {
					case '1':
						Console.WriteLine("You have taken 'Fold' option.");
                                                break;
					case '2':
						Console.WriteLine("You have taken 'Call' option.");
                                                break;
					case '3':
                                                Console.WriteLine("You have taken 'Raise' option. Please enter the new amount: ");
                                                Console.Read();
						break;
				}
//				switch (option)
//				{
//					case '1':
//                                                Console.WriteLine("You have taken 'Bet' option. Please enter the amount you want to bet: ");
//						int pot = Console.Read();
//                                                Console.WriteLine($"This player has bet {pot} chips. Now the following players are going to choose 'Fold', 'Call' or 'Raise'");
//						break;
//                                        case '2':
//                                                Console.WriteLine("You have taken 'Check' option.");
//                                                break;
//					case '3':
//                    				Console.WriteLine("You have taken 'Fold' option.");
//                    				break;
//               			case '4':
//                    				Console.WriteLine("You have taken 'Call' option.");
//                    				break;
//                			case '5':
//                    				Console.WriteLine("You have taken 'Raise' option. Please enter the new amount: ");
//						Console.Read();
//                    				break;
//                			default:
//                    				Console.WriteLine(" ");
//                    			break;
        		}
		}

		public void StartPreFlop()
        	{
            		Console.WriteLine("Pre-Flop betting round begins ... Please choose your action: ");
        	}
        	
		public void StartFlop()
        	{
            		Console.WriteLine("Flop betting round begins ... Please choose your action: ");
        	}
        	public void StartTurn()
        	{
            		Console.WriteLine("Turn round begins ... Please choose your action: ");
        	}
        	public void StartRiver()
        	{
            		Console.WriteLine("River betting round begins ... Please choose your action: ");
        	}
	}
}
