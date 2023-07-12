using System.Collections.Generic;
using System.Linq;
using CardRankLib;
using CardSuitLib;

namespace CardLib
{
	public class Card
	{
		private CardSuit _suit;
		private CardRank _rank;

		public CardSuit GetCardSuit() 
		{
			return _suit;
		}
		public CardRank GetCardRank()
		{
			return _rank;
		}
		public void SetCardSuit(CardSuit suit)
		{
			_suit = suit;
		}
		public void SetCardRank(CardRank rank)
		{
			_rank = rank;
		}
//		public Card(CardSuit tempSuit, CardRank tempRank)
//		{
//			tempSuit = _suit;
//			tempRank = _rank;
//		}
	}
}


