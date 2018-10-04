using System;

namespace Classes9
{
	/// <summary>
	/// Summary description for Colour.
	/// </summary>
	public class Colour
	{
		private string name;
		public string Name 
		{
			get {return name;}
			set {name=value;}
		}
		public Colour(string c)
		{
				name = c;
		}
	}
}
