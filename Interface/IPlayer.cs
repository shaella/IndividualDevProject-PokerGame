namespace IPlayerLib
{
	public interface IPlayer
	{
		string GetID();
		bool SetID(string ID);
		string GetName();
		bool SetName(string name);
		int GetChips();
		bool SetChips(int chips);
	}
}
