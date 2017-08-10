namespace BackToBg.Core.Models.EntityInterfaces
{
	public interface IFood
	{
		int ID { get; }
		string Name { get; }
		int Price { get; set; }
		int Stamina { get; }
		string ToString();
	}
}
