using IPlayerLib;
namespace PlayerLib
{
	public class Player : IPlayer
	{
		private string _ID;
		private string _name;
		private int _chips;
		public string GetID()
		{
			return _ID;
		}
		public string GetName()
		{
			return _name;
		}
		public int GetChips() 
		{
			return _chips;
		}
		public bool SetChips(int chips)
		{
			if(chips > 0)
			{
				_chips = chips;
				return true;
			}
			else
			{
				return false;
			}		
		}
		public bool SetName(string name) 
		{
			if(name.Length >= 1)
			{
				_name = name;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool SetID(string ID) 
		{
			if(ID.Length >= 1)
			{
				_ID = ID;
				return true;
			}
			else
			{
				return false;
			}
		}
//		public Player(string names, string IDs)
//		{
//			names = _name;
//			IDs = _ID;
//		}
	}
}

